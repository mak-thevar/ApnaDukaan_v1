using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Services;
using AuthenticationAndAuthorizationPOC.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApnaDukaan_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly IConfiguration configuration;

        public AuthController(IServiceManager serviceManager, IConfiguration configuration)
        {
            this.serviceManager = serviceManager;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequestDTO userLoginRequestDTO)
        {
            var user = await this.serviceManager.AuthService.ValidateUser(userLoginRequestDTO);
         
            return Ok(user);
        }
    }
}
