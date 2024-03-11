using Core.CrossCuttingConcerns.Exceptions;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Posts.Rules;

public class PostBusinessRules
{
    private readonly ISavedFilmRepository _savedFilmRepository;

    public PostBusinessRules(ISavedFilmRepository savedFilmRepository)
    {
        _savedFilmRepository = savedFilmRepository;
    }

    public async Task CheckIfUserWatchedFilmAboutToPost(string userId, string filmId)
    {
        SavedFilm? foundSavedFilm = await _savedFilmRepository.GetAsync(x => x.UserId == userId && x.FilmId == filmId);
        if (foundSavedFilm is null)
            throw new BusinessException("Film hasn't been added to the user yet");
        if(foundSavedFilm.Status == SavedFilmStatus.NOT_WATCHED)
            throw new BusinessException("Film hasn't been saved as watched status to the user yet");
    }
}