using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Services.ApiClients;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Films.Queries.SearchFilm;

public partial class SearchFilmQuery : IRequest<SearchFilmListModel>
{
    public string Name { get; set; }
    public string? ReleaseYear { get; set; }
    public int Page { get; set; } = 1;
    public sealed class SearchFilmQueryHandler : IRequestHandler<SearchFilmQuery, SearchFilmListModel>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ITMDBApiClient _apiClient;
        private readonly IMapper _mapper;

        public SearchFilmQueryHandler(ITMDBApiClient apiClient, IMapper mapper, IGenreRepository genreRepository)
        {
            _apiClient = apiClient;
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<SearchFilmListModel> Handle(SearchFilmQuery request, CancellationToken cancellationToken)
        {
            ExternalApiSearchFilmResponseDto externalApiSearchFilmResponseDto
                            = await _apiClient.SearchFilmsByQueryAsync(request.Name, request.Page, request.ReleaseYear);

            List<SearchFilmListDto> mappedSearchFilmResponseModelData = _mapper.Map<List<SearchFilmListDto>>(externalApiSearchFilmResponseDto.Results);
            
            MapGenrePropertyOfSearchFilmResponseModelData(mappedSearchFilmResponseModelData);

            Paginate<SearchFilmListDto> paginatedResult = new Paginate<SearchFilmListDto>()
            {
                Index = request.Page - 1,
                Size = 20,
                From = 0,
                Count = externalApiSearchFilmResponseDto.Total_Results,
                Items = mappedSearchFilmResponseModelData,
                Pages = externalApiSearchFilmResponseDto.Total_Pages
            };

            SearchFilmListModel searchFilmListModel = _mapper.Map<SearchFilmListModel>(paginatedResult);

            return searchFilmListModel;
        }

        private void MapGenrePropertyOfSearchFilmResponseModelData(
            List<SearchFilmListDto> mappedSearchFilmResponseModelData)
        {
            mappedSearchFilmResponseModelData.ForEach((response) =>
            {
                response.Genres.ForEach((genre) =>
                {
                    Genre fetchedGenre = _genreRepository.Get(x => x.Id == genre.Id);
                    genre.Name = fetchedGenre.Name;
                });
            });
        }
    }
}



