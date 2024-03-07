using AutoMapper;
using MediatR;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Rules;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Genres.Commands.CreateGenre;

public sealed class CreateGenreCommand : IRequest<CreatedGenreDto>
{
    public string Name { get; set; }
    public sealed class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreatedGenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<CreatedGenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            _genreBusinessRules.CheckGenreAlreadyExistsByName(request.Name);

            Genre newGenre = _mapper.Map<Genre>(request);
            Genre addedGenre = await _genreRepository.AddAsync(newGenre);

            return _mapper.Map<CreatedGenreDto>(addedGenre);
        }
    }
}