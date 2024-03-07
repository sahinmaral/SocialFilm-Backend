using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace SocialFilm.Domain.Entities;

public class Comment : Entity
{
    public User User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string PostId { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string? PreviousCommentId { get; set; }
    public Comment? PreviousComment { get; set; }
    public List<Comment> SubComments { get; set; } = new List<Comment>();
}