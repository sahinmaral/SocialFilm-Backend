using FluentValidation;
using SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;

namespace SocialFilm.Application.Features.Comments.Queries.GetAllByPostId;

public class GetAllByPostIdCommandValidator : AbstractValidator<GetAllByPostIdCommand>
{
    public GetAllByPostIdCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());
        
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0);
    }
}