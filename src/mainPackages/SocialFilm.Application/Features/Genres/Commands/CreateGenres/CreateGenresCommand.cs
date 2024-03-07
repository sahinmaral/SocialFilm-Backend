using AutoMapper;
using MediatR;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Rules;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Genres.Commands.CreateGenres;

public sealed class CreateGenresCommand : IRequest<List<CreatedGenreDto>>
{
    public List<string> Names { get; set; }

    public CreateGenresCommand(List<string> names)
    {
        Names = names;
    }
    public sealed class CreateGenresCommandHandler : IRequestHandler<CreateGenresCommand, List<CreatedGenreDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public CreateGenresCommandHandler(IGenreRepository genreRepository, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<List<CreatedGenreDto>> Handle(CreateGenresCommand request, CancellationToken cancellationToken)
        {
            request.Names.ForEach((name) =>
            {
                _genreBusinessRules.CheckGenreAlreadyExistsByName(name);
            });

            List<Genre> newGenres = request.Names.Select((name) => new Genre()
            {
                Name = name
            }).ToList();

            newGenres.ForEach((genre) =>
            {
                _genreRepository.Add(genre);
            });

            return _mapper.Map<List<CreatedGenreDto>>(newGenres);
        }
    }
}