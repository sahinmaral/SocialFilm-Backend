using Core.Persistence.Repositories;

namespace SocialFilm.Domain.Entities;

public class Post : Entity
{
    public string FilmId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<PostPhoto> PostPhotos { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}