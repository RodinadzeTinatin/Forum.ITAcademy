using Forum.Contracts;
using Forum.Models;
using Forum.Service.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/topics")]
    [ApiController]
    //[Authorize]
    public class TopicController : Controller
    {

        private readonly ITopicService _topicService;
        private ApiResponse _response;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
            _response = new();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTopics()
        {
            var result = await _topicService.GetAllTopics();
            _response.IsSuccess = true;
            _response.Result = result;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";
            return StatusCode(_response.StatusCode, _response);

        }

        [HttpGet("all/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetTopicsOfUser(string userId)
        {
            
            var result = await _topicService.GetTopicsOfUserAsync(userId);
            _response.IsSuccess = true;
            _response.Result = result;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";
        
            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("{topicId}")]
        [Authorize]
        public async Task<IActionResult> GetTopicById(int topicId)
        {
            var result = await _topicService.GetTopicsById(topicId);
            _response.IsSuccess = true;
            _response.Result = result;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";

            return StatusCode(_response.StatusCode, _response);

        }

        [HttpGet("{topicId}/comments")]
        //[Authorize]
        public async Task<IActionResult> GetCommentsOfTopic(int topicId)
        {
            var result = await _topicService.GetCommentsOfTopicAsync(topicId);
            _response.IsSuccess = true;
            _response.Result = result;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Request completed successfully";
           
            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddTopicToUser([FromForm] TopicForCreatingDto model)
        {
            await _topicService.AddTopicAsync(model);
            _response.IsSuccess = true;
            _response.Result = model;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Topic added to user successfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteUsersTodo(int id)
        {
           
            await _topicService.DeleteTopicAsync(id);
            _response.IsSuccess = true;
            _response.Result = null;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Todo deleted successfully";
            
            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("patch/{topicId:int}")]
        [Authorize]

        public async Task<IActionResult> UpdateTodo([FromRoute] int topicId, [FromBody] JsonPatchDocument<TopicForUpdatingDto> patchDocument)
        {
           await _topicService.UpdateTopicAsync(topicId, patchDocument);

            _response.Result = patchDocument;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Todo updated successfully";
            
            return StatusCode(_response.StatusCode, _response);
        }
    }
}
