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

namespace Forum.Service.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TopicService(ITopicRepository topicRepository, ICommentRepository commentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _commentRepository = commentRepository;
            _topicRepository = topicRepository;
            _mapper = MappingInitializer.Initialize();
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TopicForGettingDto>> GetAllTopics()
        {

            var topics = await _topicRepository.GetAllTopicsAsync();


            var result = _mapper.Map<List<TopicForGettingDto>>(topics);

            foreach (var topicDto in result)
            {
                var topic = topics.First(t => t.Id == topicDto.Id);
                topicDto.CommentCount = topic.Comments?.Count ?? 0;
                topicDto.Comments = null;
            }
            return result;
        }
        public async Task<TopicForGettingDto> GetTopicsById(int id)
        {
            if (id <= 0 )
                throw new ArgumentException("Invalid argument passed");
            var rawResult = await _topicRepository.GetSingleTopicAsync(x=> x.Id == id);
            
            if (rawResult == null)
                throw new TopicNotFoundException();

            var result = _mapper.Map<TopicForGettingDto>(rawResult);
            
            result.CommentCount = result.Comments?.Count ?? 0;
            
            return result;
        }
        public async Task<List<TopicForGettingDto>> GetTopicsOfUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("Invalid argument passed");


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundExcpetion();

            var rawTopics = await _topicRepository.GetAllTopicsAsync(x => x.UserId.Trim() == userId.Trim());
            var result = _mapper.Map<List<TopicForGettingDto>>(rawTopics);

            foreach (var topicDto in result)
            {
                var topic = rawTopics.First(t => t.Id == topicDto.Id);
                topicDto.CommentCount = topic.Comments?.Count ?? 0;
                topicDto.Comments = null;

            }

            return result;
        }
        public async Task<List<CommentForGettingDto>> GetCommentsOfTopicAsync(int topicId)
        {
            var topic = await _topicRepository.GetSingleTopicAsync(x => x.Id == topicId);
            if (topic == null)
                throw new TopicNotFoundException();

            if (topic.Comments == null)
                throw new CommentNotFoundException();

            return _mapper.Map<List<CommentForGettingDto>>(topic.Comments);
        }
        
        public async Task AddTopicAsync(TopicForCreatingDto topicForCreatingDto)
        {
            if (topicForCreatingDto is null)
                throw new ArgumentNullException("Invalid argument passed");
            
            if (topicForCreatingDto.UserId == AuthenticatedUserId() || AuthenticatedUserRole().Trim() == "Admin")
            {
                var result = _mapper.Map<Topic>(topicForCreatingDto);
                await _topicRepository.AddTopicAsync(result);
                await _topicRepository.Save();
            }
            else
            {
                throw new UnauthorizedAccessException("Can't add another users topic");
            }

        }
        public async Task UpdateTopicAsync(int topicId, JsonPatchDocument<TopicForUpdatingDto> patchDocument)
        {
            if (topicId <= 0)
                throw new ArgumentException("Invalid argument passed");

            Topic rawTodo = await _topicRepository.GetSingleTopicAsync(x => x.Id == topicId);

            if (rawTodo == null)
                throw new TopicNotFoundException();

            if (rawTodo.UserId == AuthenticatedUserId() || AuthenticatedUserRole().Trim() == "Admin")
            {
                TopicForUpdatingDto todoToPatch = _mapper.Map<TopicForUpdatingDto>(rawTodo);

                patchDocument.ApplyTo(todoToPatch);
                _mapper.Map(todoToPatch, rawTodo);

                await _topicRepository.Save();
            }
            else
            {
                throw new UnauthorizedAccessException("Can't change another users topic");
            }
            
        }
        public async Task DeleteTopicAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid argument passed");

            var rawTopic = await _topicRepository.GetSingleTopicAsync(x => x.Id == id);

            if (rawTopic == null)
                throw new TopicNotFoundException();

            if (rawTopic.UserId == AuthenticatedUserId().Trim()|| AuthenticatedUserRole().Trim() == "Admin")
            {
                var comments = await _commentRepository.GetAllCommentsAsync(x => x.TopicId == id);
                foreach (var comment in comments)
                {
                    _commentRepository.DeleteComment(comment);
                }

                _topicRepository.DeleteTopic(rawTopic);
                await _topicRepository.Save();
            }
            else
            {
                throw new UnauthorizedAccessException("Can't delete other user's topic");
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
