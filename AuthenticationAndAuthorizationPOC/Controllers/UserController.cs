using AuthenticationAndAuthorizationPOC.BLL;
using AuthenticationAndAuthorizationPOC.BLL.DTOs;
using AuthenticationAndAuthorizationPOC.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenticationAndAuthorizationPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await userService.IsValidUser(loginRequestDTO);
            if(result is not null)
            {
                var iss = configuration["JWT:ValidIssuer"];
                var aud = configuration["JWT:ValidAudience"];
                var secret = configuration["JWT:Secret"];
                var token = JWTTokenManager.GenerateToken(iss, aud, result.UserId.ToString(), result.Username, result.RoleName, secret);
                result.LoginToken = token;
                return Ok(result);
            }

            return Unauthorized(new { message = "Invalid Login!" });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var roleName = User.Claims.Where(x=>x.Type == ClaimTypes.Role).FirstOrDefault();

            return Ok($"You are having {roleName.Value} Role");
        }


        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetForAdmin()
        {
            return Ok("You are an ADMIN!");
        }
    }
}
