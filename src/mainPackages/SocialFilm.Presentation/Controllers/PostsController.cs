using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Films.Commands.SaveFilm;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Features.Posts.Commands.CreatePost;
using SocialFilm.Application.Features.Posts.Commands.DeletePost;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Application.Features.Posts.Queries.GetAllByUserId;
using SocialFilm.Application.Features.Posts.Queries.GetById;
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        DeletePostCommand request = new()
        {
            Id = id
        };
        await mediator.Send(request);
        return NoContent();
    }

    [HttpGet("GetAllByUserId/{userId}")]
    public async Task<IActionResult> GetAllByUserId([FromRoute] string userId)
    {
        GetAllByUserIdCommand request = new GetAllByUserIdCommand()
        {
            UserId = userId
        };
        
        PostsByUserIdListModel allPostsOfUser = await mediator.Send(request);
        return Ok(allPostsOfUser);
    }
    
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        GetByIdCommand request = new GetByIdCommand()
        {
            Id = id
        };
        
        PostByIdDto foundPost = await mediator.Send(request);
        return Ok(foundPost);
    }
}