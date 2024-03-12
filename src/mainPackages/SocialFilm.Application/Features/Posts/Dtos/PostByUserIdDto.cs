using SocialFilm.Application.Features.Genres.Dtos;

namespace SocialFilm.Application.Features.Posts.Dtos;

public class PostByUserIdDto
{
    public string Id { get; set; }
    public PostByUserIdFilmDetailDto FilmDetail { get; set; }
    public string Content { get; set; }
    public List<string> Photos { get; set; }
}

public class PostByUserIdFilmDetailDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string PosterPath { get; set; } = null!;
    public string BackdropPath { get; set; } = null!;
    public List<ReadGenreDto> Genres { get; set; } = new();
}