using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using SocialFilm.Application.Features.Auths.Commands.RegisterUser;
using SocialFilm.Application.Features.Auths.Dtos;

namespace SocialFilm.Application.Features.Auths.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserCommand, User>();
        CreateMap<User, RegisteredUserDto>();

        CreateMap<User, LoggedUserDto>();
    }
}