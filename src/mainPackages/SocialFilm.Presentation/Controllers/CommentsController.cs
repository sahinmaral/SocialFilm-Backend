using Microsoft.AspNetCore.Mvc;
using SocialFilm.Application.Features.Comments.Commands.CreateComment;
using SocialFilm.Application.Features.Comments.Commands.DeleteComment;
using SocialFilm.Application.Features.Comments.Dtos;
using SocialFilm.Application.Features.Comments.Models;
using SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;
using SocialFilm.Application.Features.Comments.Queries.GetAllByPostId;
using SocialFilm.Presentation.Controllers.Common;

namespace SocialFilm.Presentation.Controllers;

public class CommentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentCommand request)
    {
        CreatedCommentDto comment = await mediator.Send(request);
        return Created("", comment);
    }

    [HttpGet("GetAllByParentCommentId")]
    public async Task<IActionResult> Create([FromQuery] GetAllByParentIdCommand request)
    {
        CommentsByParentIdListModel comments = await mediator.Send(request);
        return Ok(comments);
    }
    
    [HttpGet("GetAllByPostId")]
    public async Task<IActionResult> Create([FromQuery] GetAllByPostIdCommand request)
    {
        CommentsByPostIdListModel comments = await mediator.Send(request);
        return Ok(comments);
    }
    
    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        DeleteCommentCommand request = new DeleteCommentCommand()
        {
            Id = id
        };
        DeletedCommentDto comment = await mediator.Send(request);
        return NoContent();
    }
}