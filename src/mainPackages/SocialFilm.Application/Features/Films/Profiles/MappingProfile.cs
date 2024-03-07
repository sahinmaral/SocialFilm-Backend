using AutoMapper;
using Core.Persistence.Paging;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Films.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExternalApiFilmResponseDto, FilmDetail>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Backdrop_path))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Poster_path))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Release_Date));

        CreateMap<ExternalApiFilmResponseDto, SearchFilmListDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Release_Date))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Backdrop_path))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Poster_path))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genre_ids.Select(id => new ReadGenreDto { Id = id.ToString() } )));    
        
        CreateMap<IPaginate<SearchFilmListDto>, SearchFilmListModel>();
    }
}