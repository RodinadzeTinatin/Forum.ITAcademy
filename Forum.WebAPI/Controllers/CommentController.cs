using Forum.Contracts;
using Forum.Models;
using Forum.Service.Exceptions;
using Forum.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;
        private ApiResponse _response;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
            _response = new();
        }


        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetCommentsOfUser(string userId)
        {
           var result = await _commentService.GetCommentsOfUserAsync(userId);
                _response.IsSuccess = true;
                _response.Result = result;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Request completed successfully";
         
            return StatusCode(_response.StatusCode, _response);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddCommentToTopic([FromForm] CommentForCreatingDto model)
        {
            await _commentService.AddCommentAsync(model);
            _response.IsSuccess = true;
            _response.Result = model;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Todo added to user successfully";
         
            return StatusCode(_response.StatusCode, _response);

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUsersComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            _response.IsSuccess = true;
            _response.Result = null;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Todo deleted successfully";
           
            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("{commentId:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] JsonPatchDocument<CommentForUpdatingDto> patchDocument)
        {
            await _commentService.UpdateCommentAsync(commentId, patchDocument);

            _response.Result = patchDocument;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Todo updated successfully";
            
            return StatusCode(_response.StatusCode, _response);
        }

    }
}
