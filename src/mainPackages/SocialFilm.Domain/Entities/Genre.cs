using Core.Persistence.Repositories;

namespace SocialFilm.Domain.Entities
{
    public class Genre : Entity
    {
        public string Name { get; set; } = null!;
        public List<FilmDetailGenre> FilmDetailGenres { get; set; } = new List<FilmDetailGenre>();
    }
}