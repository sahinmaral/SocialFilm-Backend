using Core.CrossCuttingConcerns.Exceptions;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Genres.Rules;

public class GenreBusinessRules
{
    private readonly IGenreRepository _genreRepository;

    public GenreBusinessRules(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public void CheckGenreAlreadyExistsByName(string name)
    {
        Genre? foundGenre = _genreRepository.Get(x => x.Name == name);
        if (foundGenre is not null)
            throw new BusinessException("Genre already exists");
    }

    public void CheckGenreDoesNotFound(Genre? genre)
    {
        if (genre is null)
            throw new EntityNotFoundException("Genre does not found");
    }
}