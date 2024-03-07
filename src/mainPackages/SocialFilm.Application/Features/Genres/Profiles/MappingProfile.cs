using AutoMapper;
using Core.Persistence.Paging;
using SocialFilm.Application.Features.Genres.Commands.CreateGenre;
using SocialFilm.Application.Features.Genres.Commands.UpdateGenre;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Models;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Genres.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateGenreCommand, Genre>();
        CreateMap<Genre, CreatedGenreDto>();

        CreateMap<IPaginate<Genre>, GenreListModel>();
        CreateMap<Genre, GenreListDto>();

        CreateMap<Genre, GenreGetByIdDto>();

        CreateMap<Genre, ReadGenreDto>();

        CreateMap<UpdateGenreCommand, Genre>();
        CreateMap<Genre, UpdatedGenreDto>();
    }
}