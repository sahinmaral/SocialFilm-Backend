using Core.Persistence.Repositories;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Domain.Entities;

public class SavedFilm : Entity
{
    public string UserId { get; set; } = null!;
    public string FilmId { get; set; } = null!;
    public FilmDetail Film { get; set; } = new();
    public SavedFilmStatus Status { get; set; }
}