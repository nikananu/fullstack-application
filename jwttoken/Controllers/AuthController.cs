using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Account.Application.Dtos;
using MyProject.Account.Application.Features.Login;
using MyProject.Account.Application.Features.Register;

namespace MyProject.jwttoken.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUserHandler _registerHandler;
        private readonly LoginUserHandler _loginHandler;


        public AuthController(
            RegisterUserHandler registerHandler,
            LoginUserHandler loginHandler)
        {
            _registerHandler = registerHandler;
            _loginHandler = loginHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequestDto dto)
        {
            var result = await _registerHandler.Handle(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _loginHandler.Handle(dto);
            return Ok(result);
        }
    }
}
