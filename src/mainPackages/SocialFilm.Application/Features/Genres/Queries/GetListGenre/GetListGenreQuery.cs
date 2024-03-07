using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using SocialFilm.Application.Features.Genres.Models;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Brands.Queries.GetListGenre;

public partial class GetListGenreQuery : IRequest<GenreListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGenreQueryHandler : IRequestHandler<GetListGenreQuery, GenreListModel>
    {
        public GetListGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public async Task<GenreListModel> Handle(GetListGenreQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Genre> genres = await _genreRepository
                .GetListAsync(
                size: request.PageRequest.PageSize,
                index: request.PageRequest.Page,
                orderBy: query => query.OrderBy(g => g.Name)
                );

            GenreListModel genreListModel = _mapper.Map<GenreListModel>(genres);

            return genreListModel;
        }
    }
}