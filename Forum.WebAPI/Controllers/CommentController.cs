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
            try
            {
                var result = await _commentService.GetCommentsOfUserAsync(userId);
                _response.IsSuccess = true;
                _response.Result = result;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Request completed successfully";
            }
            catch (ArgumentException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (TopicNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddCommentToTopic([FromForm] CommentForCreatingDto model)
        {
            try
            {
                await _commentService.AddCommentAsync(model);
                _response.IsSuccess = true;
                _response.Result = model;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Todo added to user successfully";
            }
            catch (ArgumentNullException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }
            return StatusCode(_response.StatusCode, _response);

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUsersComment(int id)
        {
            try
            {
                await _commentService.DeleteCommentAsync(id);
                _response.IsSuccess = true;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Todo deleted successfully";
            }
            catch (ArgumentNullException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (TopicNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }
            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPatch("{commentId:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] JsonPatchDocument<CommentForUpdatingDto> patchDocument)
        {
            try
            {
                await _commentService.UpdateCommentAsync(commentId, patchDocument);

                _response.Result = patchDocument;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Todo updated successfully";
            }
            catch (ArgumentNullException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (TopicNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }
            return StatusCode(_response.StatusCode, _response);
        }

    }
}
