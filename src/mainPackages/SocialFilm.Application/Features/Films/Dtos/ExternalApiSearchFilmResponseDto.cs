namespace SocialFilm.Application.Features.Films.Dtos;

public class ExternalApiSearchFilmResponseDto
{
    public int Page { get; set; }
    public List<ExternalApiFilmResponseDto> Results { get; set; } = new List<ExternalApiFilmResponseDto>();
    public int Total_Pages { get; set; }
    public int Total_Results { get; set; }
}