namespace SocialFilm.Application.Features.Films.Dtos;

public class ExternalApiFilmBaseResponseDto
{
    public int Id { get; set; }
    public string Backdrop_path { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Overview { get; set; } = null!;
    public string Poster_path { get; set; } = null!;
    public string Release_Date { get; set; } = null!;
}
