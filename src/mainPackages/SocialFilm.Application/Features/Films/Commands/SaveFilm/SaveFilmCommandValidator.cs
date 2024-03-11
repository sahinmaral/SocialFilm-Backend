using FluentValidation;
using SocialFilm.Application.Features.Films.Queries.GetSavedFilmsOfUser;

namespace SocialFilm.Application.Features.Films.Commands.SaveFilm;

public class SaveFilmCommandValidator : AbstractValidator<SaveFilmCommand>
{
    public SaveFilmCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.UserId).NotEqual(Guid.Empty.ToString());
        
        RuleFor(x => x.FilmId).NotEmpty();
        RuleFor(x => x.FilmId).NotEqual(Guid.Empty.ToString());
    }
}
