using AutoMapper;
using MediatR;
using SocialFilm.Application.Features.Genres.Dtos;
using SocialFilm.Application.Features.Genres.Rules;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Genres.Commands.UpdateGenre;

public sealed class UpdateGenreCommand : IRequest<UpdatedGenreDto>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, UpdatedGenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly GenreBusinessRules _genreBusinessRules;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper, GenreBusinessRules genreBusinessRules)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _genreBusinessRules = genreBusinessRules;
        }

        public async Task<UpdatedGenreDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            _genreBusinessRules.CheckGenreAlreadyExistsByName(request.Name);

            Genre mappedGenre = _mapper.Map<Genre>(request);
            Genre updatedGenre = await _genreRepository.UpdateAsync(mappedGenre);

            return _mapper.Map<UpdatedGenreDto>(updatedGenre);
        }
    }
}