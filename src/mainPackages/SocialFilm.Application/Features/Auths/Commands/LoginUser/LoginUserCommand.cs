using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using SocialFilm.Application.Features.Auths.Dtos;
using SocialFilm.Application.Features.Auths.Rules;

namespace SocialFilm.Application.Features.Auths.Commands.LoginUser;

public class LoginUserCommand : IRequest<LoggedUserDto>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoggedUserDto>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginUserCommandHandler(AuthBusinessRules authBusinessRules, IJwtProvider jwtProvider, IMapper mapper)
        {
            _authBusinessRules = authBusinessRules;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task<LoggedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User loggedInUser = await _authBusinessRules.CheckUserWithEmailOrUsernameExists(request.UsernameOrEmail);

            await _authBusinessRules.CheckIfUserEnteredCorrectPassword(loggedInUser, request.Password);

            //TODO: E-posta doğrulaması yerine telefon numarası doğrulaması yapılabilir
            //await _authBusinessRules.CheckIfUserEmailHasBeenVerified(loggedInUser);

            TokenResponse tokenResponse = await _jwtProvider.CreateTokenAsync(loggedInUser);

            LoggedUserDto loggedUserDto = _mapper.Map<LoggedUserDto>(loggedInUser);
            loggedUserDto.AccessToken = tokenResponse.AccessToken;
            loggedUserDto.RefreshToken = tokenResponse.RefreshToken;
            loggedUserDto.RefreshTokenExpires = tokenResponse.RefreshTokenExpires;

            return loggedUserDto;
        }
    }
}
