using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Features.Films.Queries.SearchFilm;
using SocialFilm.Application.Features.Films.Commands.SaveFilm;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Films.Queries.GetSavedFilmsOfUser;
using SocialFilm.Application.Features.Films.Rules;
using SocialFilm.WebAPI.Controllers.Common;

namespace SocialFilm.Presentation.Controllers;

public class FilmsController : BaseController
{
    [HttpPost("SaveFilm")]
    public async Task<IActionResult> SaveFilm([FromBody] SaveFilmCommand request)
    {
        CreatedSavedFilmDto response = await mediator.Send(request);
        return Created("", response);
    }

    [HttpGet("SearchFilm")]
    public async Task<IActionResult> SearchFilm([FromQuery] SearchFilmQuery request)
    {
        SearchFilmListModel response = await mediator.Send(request);
        return Ok(response);
    }
    
    [HttpGet("GetSavedFilmsOfUser")]
    public async Task<IActionResult> GetSavedFilmsOfUser([FromQuery] GetSavedFilmsOfUserQuery request)
    {
        SavedFilmsOfUserListModel response = await mediator.Send(request);
        return Ok(response);
    }
}