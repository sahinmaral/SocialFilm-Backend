using AutoMapper;
using Core.Persistence.Paging;
using SocialFilm.Application.Features.Films.Models;
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

        CreateMap<IPaginate<Post>, PostsByUserIdListModel>(); 
        
        CreateMap<Post, PostByUserIdDto>()
            .ForMember(dest => dest.FilmDetail, opt => opt.MapFrom(src => src.Film))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.PostPhotos.Select(pp => pp.PhotoPath)));
        
        CreateMap<Post, PostByIdDto>()
            .ForMember(dest => dest.FilmDetail, opt => opt.MapFrom(src => src.Film))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.PostPhotos.Select(pp => pp.PhotoPath)));

        CreateMap<FilmDetail, PostByIdFilmDetailDto>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmDetailGenres)); 
        
        CreateMap<FilmDetail, PostByUserIdFilmDetailDto>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmDetailGenres));
    }
}