using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotFinder.Application.ViewModels;
using SpotFinder.Application.Interfaces;
namespace SpotFinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            var tokenString = await _authService.Register(registerUserViewModel);
            
            if(tokenString != "")
                return Ok(new { tokenString });

            return BadRequest("User cannot be created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            var tokenString = await _authService.Login(loginViewModel);

            if (tokenString != "")
                return Ok(new { tokenString });

            return Unauthorized();
        }

        [Route("getUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var userExists = await _authService.GetUserByEmail(email);
            return Ok(userExists);
        }
    }
}