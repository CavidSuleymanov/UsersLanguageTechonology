using Application.Features.Auth.Commands.LoginUser;
using Application.Features.Auth.Dtos;
using Application.Features.Users.Commands.CreateUserCommand;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommand createUserCommand = new RegisterUserCommand {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };
           RegisteredDto result= await Mediator.Send(createUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);

            return Created("",result.AccessToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginUserCommand loginUserCommand = new LoginUserCommand
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };
            LoginDto result = await Mediator.Send(loginUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
