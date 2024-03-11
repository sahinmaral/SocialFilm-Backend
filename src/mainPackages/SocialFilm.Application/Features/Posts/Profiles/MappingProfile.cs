using AutoMapper;
using SocialFilm.Application.Features.Posts.Commands.CreatePost;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Posts.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, CreatedPostDto>()
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.PostPhotos.Select(pp => pp.PhotoPath)));

        CreateMap<CreatePostCommand, Post>();
        CreateMap<Post, DeletedPostDto>();
        
        
    }
}