using FluentValidation;

namespace SocialFilm.Application.Features.Genres.Commands.CreateGenre;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Name).MinimumLength(2);
    }
}