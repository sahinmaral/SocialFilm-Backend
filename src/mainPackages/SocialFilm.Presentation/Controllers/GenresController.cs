using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Brands.Queries.GetByIdGenre;
using SocialFilm.Application.Features.Brands.Queries.GetListGenre;
using SocialFilm.Application.Features.Genres.Commands.CreateGenre;
using SocialFilm.Application.Features.Genres.Commands.CreateGenres;
using SocialFilm.Application.Features.Genres.Commands.UpdateGenre;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Models;
using SocialFilm.Presentation.Controllers.Common;

public class GenresController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateGenreCommand request)
    {
        CreatedGenreDto response = await mediator.Send(request);
        return Created("", response);
    }

    [HttpPost("AddRange")]
    public async Task<IActionResult> AddRangeAsync([FromBody] List<string> Names)
    {
        var request = new CreateGenresCommand(Names);

        List<CreatedGenreDto> response = await mediator.Send(request);
        return Created("", response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreCommand request)
    {
        UpdatedGenreDto response = await mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync([FromQuery] PageRequest request)
    {
        GetListGenreQuery getListBrandQuery = new()
        {
            PageRequest = request
        };

        GenreListModel response = await mediator.Send(getListBrandQuery);
        return Ok(response);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] GetByIdGenreQuery request)
    {
        GenreGetByIdDto response = await mediator.Send(request);
        return Ok(response);
    }
}