using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Application.Services.ApiClients;

public interface ITMDBApiClient
{
    Task<ExternalApiSearchFilmResponseDto> SearchFilmsByQueryAsync(string name, int page, string? releaseYear);
    Task<ExternalApiFilmResponseDto> GetFilmByIdAsync(string id);
}
