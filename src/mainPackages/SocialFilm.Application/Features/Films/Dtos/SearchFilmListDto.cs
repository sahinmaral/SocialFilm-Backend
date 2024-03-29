using SocialFilm.Application.Features.Genres.Dtos;

namespace SocialFilm.Application.Features.Films.Dtos;

public sealed class SearchFilmListDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string PosterPath { get; set; } = null!;
    public string BackdropPath { get; set; } = null!;
    public List<ReadGenreDto> Genres { get; set; } = new();
}