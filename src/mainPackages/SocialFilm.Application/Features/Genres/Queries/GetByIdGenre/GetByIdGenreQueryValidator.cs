using FluentValidation;
using SocialFilm.Application.Features.Brands.Queries.GetByIdGenre;

namespace SocialFilm.Application.Features.Genres.Commands.GetByIdGenre;

public class GetByIdGenreQueryValidator : AbstractValidator<GetByIdGenreQuery>
{
    public GetByIdGenreQueryValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
        RuleFor(b => b.Id).MinimumLength(1);
    }
}