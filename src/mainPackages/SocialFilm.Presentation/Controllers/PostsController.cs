using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Films.Commands.SaveFilm;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Posts.Commands.CreatePost;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.WebAPI.Controllers.Common;

namespace SocialFilm.Presentation.Controllers;

public class PostsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatePostCommand request)
    {
        CreatedPostDto response = await mediator.Send(request);
        return Created("", response);
    }
}