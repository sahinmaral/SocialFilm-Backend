using Core.CrossCuttingConcerns.Exceptions;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Comments.Rules;

public class CommentBusinessRules
{
    private readonly ICommentRepository _commentRepository;

    public CommentBusinessRules(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task CheckCommentExistsById(string id)
    {
        Comment? foundComment = await _commentRepository.GetAsync(x => x.Id == id);

        if (foundComment is null)
            throw new EntityNotFoundException("Comment does not found");
    }
}