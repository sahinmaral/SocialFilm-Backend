using FluentValidation;

namespace SocialFilm.Application.Features.Posts.Queries.GetAllByUserId;

public class GetAllByUserIdCommandValidator : AbstractValidator<GetAllByUserIdCommand>
{
    public GetAllByUserIdCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());

        RuleFor(x => x.PageSize).GreaterThan(0);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(0);
    }
}