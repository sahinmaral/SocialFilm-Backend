using Refit;
using SocialFilm.Application.Services.ApiClients;
using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Infrastructure.ApiClients;

public class TMDBApiClient : ITMDBApiClient
{
    private ITMDBApi ApiClient { get; }
    public TMDBApiClient(string? bearerToken)
    {
        ApiClient = RestService.For<ITMDBApi>("https://api.themoviedb.org/3", new RefitSettings()
        {
            AuthorizationHeaderValueGetter = (message, cancellationToken) =>
                Task.FromResult(bearerToken)
        });
    }

    public async Task<ExternalApiSearchFilmsResponseDto> SearchFilmsByQueryAsync(string name, int page, string? releaseYear)
    {
        return await ApiClient.SearchFilms(name, page, releaseYear);
    }

    public async Task<ExternalApiFilmResponseDto> GetFilmByIdAsync(string id)
    {
        return await ApiClient.GetFilmById(id);
    }
}
