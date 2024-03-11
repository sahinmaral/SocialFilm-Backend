using FluentValidation;

namespace SocialFilm.Application.Features.Films.Queries.GetSavedFilmsOfUser;

public class GetSavedFilmsOfUserQueryValidator : AbstractValidator<GetSavedFilmsOfUserQuery>
{
    public GetSavedFilmsOfUserQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.UserId).MinimumLength(2);
    }
}