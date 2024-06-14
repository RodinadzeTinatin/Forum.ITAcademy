using AutoMapper;
using Forum.Contracts;
using Forum.Entities;
using Forum.Models;
using Forum.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Forum.Service.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(ICommentRepository commentRepository,ITopicRepository topicRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _commentRepository = commentRepository;
            _topicRepository = topicRepository;
            _mapper = MappingInitializer.Initialize();
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task AddCommentAsync(CommentForCreatingDto commentForCreatingDto)
        {
            if (commentForCreatingDto is null)
                throw new ArgumentNullException("Invalid argument passed");

            var topic = await _topicRepository.GetSingleTopicAsync(t => t.Id == commentForCreatingDto.TopicId);

            if (topic == null || topic.Status == Status.Inactive)
            {
                throw new InvalidOperationException("Cannot add a comment to an inactive or non-existent topic");
            }

            if (commentForCreatingDto.UserId == AuthenticatedUserId().Trim()|| AuthenticatedUserRole() == "Admin")
            {
                var result = _mapper.Map<Comment>(commentForCreatingDto);
                await _commentRepository.AddCommentAsync(result);
                await _commentRepository.Save();

            }
            else
            {
                throw new UnauthorizedAccessException("Can't add another users comments");
            }

        }

        public async Task DeleteCommentAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid argument passed");

            var rawTodo = await _commentRepository.GetSingleCommentAsync(x => x.Id == id);

            if (rawTodo == null)
                throw new CommentNotFoundException();

            if (rawTodo.UserId == AuthenticatedUserId().Trim() || AuthenticatedUserRole() == "Admin")
            {
                _commentRepository.DeleteComment(rawTodo);
                await _commentRepository.Save();
            }
            else
            {
                throw new UnauthorizedAccessException("Can't delete other user's comment");
            }
        }
        
        public async Task<List<CommentForGettingDto>> GetCommentsOfUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("Invalid argument passed");


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundExcpetion();

            var rawTopics = await _commentRepository.GetAllCommentsAsync(x => x.UserId.Trim() == userId.Trim());
            List<CommentForGettingDto> result = new();

            if (rawTopics.Count > 0)
                result = _mapper.Map<List<CommentForGettingDto>>(rawTopics);

            return result;
        }

        public async Task<CommentForGettingDto> GetSingleCommentByUserId(int commentId, string userId)
        {
            if (commentId <= 0 || string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("Invalid argument passed");

            if (AuthenticatedUserId().Trim() != userId.Trim())
                throw new UserNotFoundExcpetion();

            var raw = await _commentRepository.GetSingleCommentAsync(x => x.Id == commentId && x.UserId == userId);

            throw new NotImplementedException();
        }

        public async Task UpdateCommentAsync(int commentcId, JsonPatchDocument<CommentForUpdatingDto> patchDocument)
        {
            if (commentcId <= 0)
                throw new ArgumentException("Invalid argument passed");

            Comment rawTodo = await _commentRepository.GetSingleCommentAsync(x => x.Id == commentcId);

            if (rawTodo == null)
                throw new CommentNotFoundException();

            if (AuthenticatedUserId().Trim() == rawTodo.UserId || AuthenticatedUserRole() == "Admin")
            {
                CommentForUpdatingDto commentToPatch = _mapper.Map<CommentForUpdatingDto>(rawTodo);

                patchDocument.ApplyTo(commentToPatch);
                _mapper.Map(commentToPatch, rawTodo);

                await _commentRepository.Save();
            }
            else
            {
                throw new UnauthorizedAccessException("Can't delete other user's comment");
            }

        }

        private string AuthenticatedUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return result;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }
        private string AuthenticatedUserRole()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
                return result;
            }
            else
            {
                throw new UnauthorizedAccessException("Can't get credentials of unauthorized user");
            }
        }
    }
}
