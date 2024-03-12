using Core.CrossCuttingConcerns.Exceptions;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Posts.Rules;

public class PostBusinessRules
{
    private readonly ISavedFilmRepository _savedFilmRepository;
    private readonly IPostRepository _postRepository;
    public PostBusinessRules(ISavedFilmRepository savedFilmRepository, IPostRepository postRepository)
    {
        _savedFilmRepository = savedFilmRepository;
        _postRepository = postRepository;
    }
    
    public async Task CheckPostExistsById(string id)
    {
        Post? foundPost = await _postRepository.GetAsync(x => x.Id == id);

        if (foundPost is null)
            throw new EntityNotFoundException("Post does not found");
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