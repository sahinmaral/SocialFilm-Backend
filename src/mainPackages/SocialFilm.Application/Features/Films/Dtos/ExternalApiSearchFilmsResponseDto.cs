namespace SocialFilm.Application.Features.Films.Dtos;

public class ExternalApiSearchFilmsResponseDto
{
    public int Page { get; set; }
    public List<ExternalApiSearchFilmResponseDto> Results { get; set; } = new List<ExternalApiSearchFilmResponseDto>();
    public int Total_Pages { get; set; }
    public int Total_Results { get; set; }
}

public class ExternalApiSearchFilmResponseDto : ExternalApiFilmBaseResponseDto
{
    public List<int> Genre_ids { get; init; } = new();
}