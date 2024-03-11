using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Films.Dtos;

public class SavedFilmsOfUserDto
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public SavedFilmStatus Status { get; set; }
    public SavedFilmsOfUserFilmDetailDto FilmDetail { get; set; }
}

public class SavedFilmsOfUserFilmDetailDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string PosterPath { get; set; } = null!;
    public string BackdropPath { get; set; } = null!;
    public List<ReadGenreDto> Genres { get; set; } = new();
}