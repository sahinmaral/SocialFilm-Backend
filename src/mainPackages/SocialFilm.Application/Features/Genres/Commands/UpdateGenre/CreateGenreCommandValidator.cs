using FluentValidation;

namespace SocialFilm.Application.Features.Genres.Commands.UpdateGenre;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Name).MinimumLength(2);

        RuleFor(b => b.Id).NotEmpty();
        RuleFor(b => b.Id).MinimumLength(1);
    }
}