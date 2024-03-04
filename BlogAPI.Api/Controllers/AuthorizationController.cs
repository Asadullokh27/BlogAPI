using BlogAPI.Application.Services.AuthServices;
using BlogAPI.Application.Services.UserServices;
using BlogAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;

        public AuthorizationController(IAuthorizationService authorizationService, IUserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<string> Register(UserDTO userDTO)
        {

            var entry = await _userService.CreateUser( userDTO);

            return "Created";
        }

        [HttpPost]
        public async Task<string> Login(LoginDTO loginDTO)
        {
            var token = await _authorizationService.GenerateToken(loginDTO);

            return token;
        }

    }
}
