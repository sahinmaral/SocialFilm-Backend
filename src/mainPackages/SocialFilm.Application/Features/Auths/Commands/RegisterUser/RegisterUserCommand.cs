using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialFilm.Application.Features.Auths.Dtos;
using SocialFilm.Application.Features.Auths.Rules;

namespace SocialFilm.Application.Features.Auths.Commands.RegisterUser;

public partial class RegisterUserCommand : IRequest<RegisteredUserDto>
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoURL { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(UserManager<User> userManager, AuthBusinessRules authBusinessRules, IMapper mapper)
        {
            _userManager = userManager;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
        }

        public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.CheckUserWithUsernameAlreadyExists(request.UserName);
            await _authBusinessRules.CheckUserWithEmailAlreadyExists(request.Email);

            User newUser = _mapper.Map<User>(request);

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, request.Password);
            if (identityResult.Succeeded)
            {
                return _mapper.Map<RegisteredUserDto>(newUser);
            }
            else
            {
                var errors = identityResult.Errors.Select(error => error.Description).ToList();

                throw new RegistrationFailedException(errors);
            }
        }
    }
}