using Refit;
using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Infrastructure.ApiClients;

public interface ITMDBApi
{
    [Get("/search/movie?query={name}&include_adult=false&page={page}")]
    [Headers("Authorization: Bearer")]
    Task<ExternalApiSearchFilmResponseDto> SearchFilms(string name, int page, string? releaseYear);

    [Get("/movie/{id}")]
    [Headers("Authorization: Bearer")]
    Task<ExternalApiFilmResponseDto> GetFilmById(string id);
}
