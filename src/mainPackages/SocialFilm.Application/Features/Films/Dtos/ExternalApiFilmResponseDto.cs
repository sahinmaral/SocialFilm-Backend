namespace SocialFilm.Application.Features.Films.Dtos;

public sealed class ExternalApiFilmResponseDto : ExternalApiFilmBaseResponseDto
{
    public List<ExternalApiFilmResponseGenreDto> Genres { get; init; } = new();
}

public sealed class ExternalApiFilmResponseGenreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}