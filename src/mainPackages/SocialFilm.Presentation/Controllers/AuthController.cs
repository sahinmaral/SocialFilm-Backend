using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Auths.Commands.LoginUser;
using SocialFilm.Application.Features.Auths.Commands.RefreshToken;
using SocialFilm.Application.Features.Auths.Commands.RegisterUser;
using SocialFilm.Application.Features.Auths.Dtos;
using SocialFilm.Presentation.Controllers.Common;

namespace SocialFilm.Presentation.Controllers;

public class AuthController : BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
    {
        RegisteredUserDto response = await mediator.Send(request);
        return Created("", response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
    {
        LoggedUserDto response = await mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand request)
    {
        RefreshedTokenDto response = await mediator.Send(request);
        return Ok(response);
    }
}
