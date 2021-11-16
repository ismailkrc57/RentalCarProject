using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.DTOs;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var token = _authService.CreateAccessToken(result.Data);

            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token.Message);

        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.UserExist(userForRegisterDto.Email);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var token = _authService.CreateAccessToken(registerResult.Data);

            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token.Message);

        }
    }
}
