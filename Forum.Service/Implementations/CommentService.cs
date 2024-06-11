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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Forum.Service.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _commentRepository = commentRepository;
            _mapper = MappingInitializer.Initialize();
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task AddCommentAsync(CommentForCreatingDto commentForCreatingDto)
        {
            if (commentForCreatingDto is null)
                throw new ArgumentNullException("Invalid argument passed");

            if (commentForCreatingDto.UserId != AuthenticatedUserId())
                throw new UnauthorizedAccessException("Can't add another users topic");

            var result = _mapper.Map<Comment>(commentForCreatingDto);
            await _commentRepository.AddCommentAsync(result);
            await _commentRepository.Save();
        }

        public async Task DeleteCommentAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid argument passed");

            var rawTodo = await _commentRepository.GetSingleCommentAsync(x => x.Id == id);

            if (rawTodo == null)
                throw new TopicNotFoundException();

            if (rawTodo.UserId == AuthenticatedUserId().Trim())
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

            //if (AuthenticatedUserId().Trim() != userId.Trim())
            //    throw new UserNotFoundExcpetion();

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
                throw new TopicNotFoundException();

            CommentForUpdatingDto commentToPatch = _mapper.Map<CommentForUpdatingDto>(rawTodo);

            patchDocument.ApplyTo(commentToPatch);
            _mapper.Map(commentToPatch, rawTodo);

            await _commentRepository.Save();
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
    }
}
