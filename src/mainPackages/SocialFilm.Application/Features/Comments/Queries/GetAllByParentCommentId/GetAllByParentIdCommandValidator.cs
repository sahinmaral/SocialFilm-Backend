using FluentValidation;
using SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;

namespace SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;

public class GetAllByParentIdCommandValidator : AbstractValidator<GetAllByParentIdCommand>
{
    public GetAllByParentIdCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());
        
        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0);
    }
}