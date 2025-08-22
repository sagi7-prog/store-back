using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Interfaces;
using Store.Entities.DTOs;

namespace Store.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _authService.Login(loginDto);
            if (token == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            return Ok(new { Token = token });
        }

    }
}
