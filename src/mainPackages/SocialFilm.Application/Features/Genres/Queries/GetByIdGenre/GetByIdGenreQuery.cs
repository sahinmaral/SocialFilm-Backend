using AutoMapper;
using MediatR;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Rules;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Brands.Queries.GetByIdGenre;

public partial class GetByIdGenreQuery : IRequest<GenreGetByIdDto>
{
    public string Id { get; set; }

    public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQuery, GenreGetByIdDto>
    {
        public GetByIdGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }

        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public async Task<GenreGetByIdDto> Handle(GetByIdGenreQuery request, CancellationToken cancellationToken)
        {
            Genre? foundGenre = await _genreRepository.GetAsync(x => x.Id == request.Id);
            _genreBusinessRules.CheckGenreDoesNotFound(foundGenre);

            return _mapper.Map<GenreGetByIdDto>(foundGenre);
        }
    }
}