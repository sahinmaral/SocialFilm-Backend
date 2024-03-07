using SocialFilm.Domain.Enums;

namespace SocialFilm.Domain.Entities;

public class UserFriend
{
    public string UserId { get; set; } = null!;
    public string FriendId { get; set; } = null!;
    public FriendRequestStatus Status { get; set; }
}