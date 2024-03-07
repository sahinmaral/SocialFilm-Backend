using Core.CrossCuttingConcerns.Exceptions;
using SocialFilm.Application.Features.Films.Constants;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Films.Rules;

public class FilmBusinessRules
{
    private readonly ISavedFilmRepository _savedFilmRepository;

    public FilmBusinessRules(ISavedFilmRepository savedFilmRepository)
    {
        _savedFilmRepository = savedFilmRepository;
    }

    public async Task CheckIfUserSavedMaximumThreeFilmsToday(string userId)
    {
        int count = await _savedFilmRepository.GetCountOfTodaySavedFilmsOfUserAsync(userId);
        if (count == FilmConstants.MaximumSavedFilmCountOfUser)
            throw new BusinessException("For your mental health, you can watch three movies a day. Instead, you can rest or save the movie of your choice as unwatched.");
    }

    public async Task CheckIfUserAlreadySavedThisFilm(string userId, string filmId, SavedFilmStatus savedFilmStatus)
    {
        SavedFilm? savedFilm = await _savedFilmRepository.GetAsync(
                    x => x.UserId == userId &&
                    x.FilmId == filmId &&
                    x.Status == savedFilmStatus
                );
        if (savedFilm is not null)
            throw new BusinessException("You already saved this film with same status");
    }
}