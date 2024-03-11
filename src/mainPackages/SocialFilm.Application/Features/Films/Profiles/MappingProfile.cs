using AutoMapper;
using Core.Persistence.Paging;
using SocialFilm.Application.Features.Films.Commands.SaveFilm;
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
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Backdrop_path))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Poster_path))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Release_Date))
            .ForMember(dest => dest.FilmDetailGenres, opt => opt.MapFrom(src => 
                src.Genres.Select(g => new FilmDetailGenre
                {
                    Genre = new Genre { Id = g.Id.ToString() },  // Assuming Genre has an Id property
                    FilmDetail = new FilmDetail { Id = src.Id.ToString() } // Assuming FilmDetail has an Id property
                })));

        CreateMap<ExternalApiSearchFilmResponseDto, SearchFilmListDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Release_Date))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Backdrop_path))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Poster_path))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genre_ids.Select(id => new ReadGenreDto { Id = id.ToString() } )));

        CreateMap<SavedFilm, SearchFilmListDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Film.Name))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Film.ReleaseYear))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Film.BackdropPath))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Film.PosterPath))
            .ForMember(dest => dest.Overview, opt => opt.MapFrom(src => src.Film.Overview));

        CreateMap<SaveFilmCommand, SavedFilm>();

        CreateMap<SavedFilm, CreatedSavedFilmDto>()
            .ForMember(dest => dest.FilmDetail, opt => opt.MapFrom(src => src.Film));

        CreateMap<FilmDetail, CreatedSavedFilmDetailDto>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmDetailGenres))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
            .ForMember(dest => dest.Overview, opt => opt.MapFrom(src => src.Overview))
            .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.PosterPath))
            .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.BackdropPath));
        
        CreateMap<IPaginate<SearchFilmListDto>, SearchFilmListModel>();
        CreateMap<IPaginate<SavedFilm>, SavedFilmsOfUserListModel>();
        
        CreateMap<FilmDetailGenre, ReadGenreDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenreId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
        
        CreateMap<FilmDetail, SavedFilmsOfUserFilmDetailDto>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.FilmDetailGenres));
        
        CreateMap<SavedFilm, SavedFilmsOfUserDto>()
            // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Film.Name))
            // .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.Film.ReleaseYear))
            // .ForMember(dest => dest.BackdropPath, opt => opt.MapFrom(src => src.Film.BackdropPath))
            // .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(src => src.Film.PosterPath))
            // .ForMember(dest => dest.Overview, opt => opt.MapFrom(src => src.Film.Overview))
            .ForMember(dest => dest.FilmDetail, opt => opt.MapFrom(src => src.Film));
        
        
        
        CreateMap<ExternalApiFilmResponseGenreDto, Genre>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}