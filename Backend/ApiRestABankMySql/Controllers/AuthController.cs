using ApiRestABankMySql.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestABankMySql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(string usuario, string password)
        {
            // Validación real va aquí
            if (usuario == "admin" && password == "123")
            {
                var token = _authService.GenerarToken(usuario);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
