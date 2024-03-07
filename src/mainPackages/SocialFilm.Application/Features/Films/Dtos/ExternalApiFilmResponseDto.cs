namespace SocialFilm.Application.Features.Films.Dtos;

public class ExternalApiFilmResponseDto : ExternalApiFilmBaseResponseDto
{
    public List<int> Genre_ids { get; set; } = new List<int>();
}
