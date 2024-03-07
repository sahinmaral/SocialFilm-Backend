using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SocialFilm.Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly UserManager<User> _userManager;

    public AuthBusinessRules(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task CheckUserExistsById(string id)
    {
        User? foundUser = await _userManager.FindByIdAsync(id);

        if (foundUser is null)
            throw new EntityNotFoundException("User does not found");
    }

    public async Task CheckUserWithUsernameAlreadyExists(string userName)
    {
        User? foundUser = await _userManager.FindByNameAsync(userName);

        if (foundUser is not null)
            throw new EntityNotFoundException("This username is already taken");
    }

    public async Task CheckUserWithEmailAlreadyExists(string email)
    {
        User? foundUser = await _userManager.FindByEmailAsync(email);

        if (foundUser is not null)
            throw new EntityNotFoundException("This e-mail address is already taken");
    }

    public async Task<User> CheckUserWithEmailOrUsernameExists(string usernameOrEmail)
    {
        User? user = await _userManager
              .Users
              .Where(x => x.UserName == usernameOrEmail || x.Email == usernameOrEmail)
              .FirstOrDefaultAsync();

        if (user is null)
            throw new EntityNotFoundException("There is no user with this username or email address");

        return user;
    }

    public async Task CheckIfUserEnteredCorrectPassword(User user, string password)
    {
        var passwordCheckResult = await _userManager.CheckPasswordAsync(user, password);
        if (!passwordCheckResult)
            throw new Exception("You entered the wrong password along with the username or email you entered.");
    }

    public Task CheckIfUserEmailHasBeenVerified(User user)
    {
        if (!user.EmailConfirmed)
            throw new Exception("Please confirm your account via the e - mail sent to the e - mail address you registered with.");

        return Task.CompletedTask;
    }
}