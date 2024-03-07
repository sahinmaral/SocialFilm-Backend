namespace SocialFilm.Application.Features.Auths.Dtos;

public class RegisteredUserDto
{
    public string Id { get; init; }
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public DateTime BirthDate { get; init; }
    public string? ProfilePhotoURL { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public RegisteredUserDto(string id, string firstName, string lastName, DateTime birthDate, string userName, string email, string? profilePhotoURL = null, string? middleName = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        ProfilePhotoURL = profilePhotoURL;
        MiddleName = middleName;
        UserName = userName;
        Email = email;
    }
}
