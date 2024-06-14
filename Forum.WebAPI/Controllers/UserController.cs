using Forum.Contracts;
using Forum.Models.Identity;
using Forum.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        private ApiResponse _response;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }


        [HttpGet("user/{email}")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);

            _response.Result = result;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "User found";
            return StatusCode(_response.StatusCode, _response);

        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromForm] RegistrationRequestDto model)
        {
            await _userService.Register(model);

            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "User registered sucessfully";

            return StatusCode(_response.StatusCode, _response);
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login([FromForm] LoginRequestDto model)
        {
            var loginResponse = await _userService.Login(model);

            if (loginResponse == null)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = "Username or password is incorrect";

                return StatusCode(_response.StatusCode, _response);
            }

            _response.Result = loginResponse;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "User logged in successfully";


            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost("registeradmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegistrationRequestDto model)
        {
            await _userService.RegisterAdmin(model);

            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "Admin registered succesfully";


            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost("user/{userId}/lockout")]
        [Authorize]
        public async Task<IActionResult> LockOutUser(string userId)
        {
            await _userService.LockOutUser(userId);
            _response.IsSuccess = true;
            _response.Result = null;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "User locked out succesfully";

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost("user/{userId}/cancellockout")]
        [Authorize]
        public async Task<IActionResult> CancelLockOut(string userId)
        {
            await _userService.CancelLockOut(userId);
            _response.IsSuccess = true;
            _response.Result = null;
            _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            _response.Message = "User's locked out is cancelled succesfully";

            return StatusCode(_response.StatusCode, _response);
        }


    }




}
