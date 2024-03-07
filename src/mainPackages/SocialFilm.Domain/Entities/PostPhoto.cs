using Core.Persistence.Repositories;

namespace SocialFilm.Domain.Entities;

public class PostPhoto : Entity
{
    public Post Post { get; set; } = new Post();
    public string PostId { get; set; } = null!;
    public string PhotoPath { get; set; } = null!;
}