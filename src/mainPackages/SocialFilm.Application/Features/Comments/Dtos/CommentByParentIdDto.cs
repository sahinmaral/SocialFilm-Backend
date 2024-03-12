namespace SocialFilm.Application.Features.Comments.Dtos;

public class CommentByParentIdDto
{
    public string Id { get; set; }
    public CommentByParentIdUserDto User { get; set; } = null!;
    public string Message { get; set; } = null!;
}

public class CommentByParentIdUserDto 
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