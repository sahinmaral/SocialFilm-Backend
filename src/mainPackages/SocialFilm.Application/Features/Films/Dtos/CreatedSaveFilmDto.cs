using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Films.Dtos;

public sealed class CreatedSavedFilmDto
{
    public SavedFilmStatus Status { get; init; }
    public CreatedSavedFilmDetailDto FilmDetail { get; init; }
};

public sealed class CreatedSavedFilmDetailDto
{
    public string Name { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string PosterPath { get; set; } = null!;
    public string BackdropPath { get; set; } = null!;
    public List<ReadGenreDto> Genres { get; set; } = new();
}