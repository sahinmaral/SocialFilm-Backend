using SocialFilm.Application.Features.Comments.Models;

namespace SocialFilm.Application.Features.Comments.Dtos;

public class CommentByPostIdDto
{
    public string Id { get; set; }
    public CommentByPostIdUserDto User { get; set; } = null!;
    public string Message { get; set; } = null!;
    public SubCommentsOfCommentsByPostIdListModel SubComments { get; set; }
}

public class CommentByPostIdUserDto 
{
    public string Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoURL { get; set; }
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
}

