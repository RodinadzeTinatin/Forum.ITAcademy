using Forum.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Contracts
{
    public interface ITopicService
    {
        Task<List<TopicForGettingDto>> GetAllTopics();
        Task<TopicForGettingDto> GetTopicsById(int id);
        Task<List<TopicForGettingDto>> GetTopicsOfUserAsync(string userId);
        //Task<TopicForGettingDto> GetSingleTopicByUserId(int topicId, string userId);
        Task<List<CommentForGettingDto>> GetCommentsOfTopicAsync(int topicId);
        Task DeleteTopicAsync(int id);
        Task AddTopicAsync(TopicForCreatingDto topicForCreatingDto);
        Task UpdateTopicAsync(int topicId, JsonPatchDocument<TopicForUpdatingDto> patchDocument);
    }
}
