using AutoMapper;

using MediatR;
using SocialFilm.Application.Features.Films.Rules;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Services.ApiClients;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;
using Core.Application.Pipelines.Authorization;

namespace SocialFilm.Application.Features.Films.Commands.SaveFilm;

public partial class SaveFilmCommand : IRequest<CreatedSavedFilmDto>, ISecuredRequest
{
    public string FilmId { get; set; }
    public string UserId { get; set; }
    public SavedFilmStatus Status { get; set; }
    public string[] Roles => new[] { "Admin", "User" };

    public class SaveFilmCommandHandler : IRequestHandler<SaveFilmCommand, CreatedSavedFilmDto>
    {
        private readonly ITMDBApiClient _tmdbApiClient;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly FilmBusinessRules _filmBusinessRules;
        private readonly ISavedFilmRepository _savedFilmRepository;
        private readonly IFilmDetailRepository _filmDetailRepository;
        private readonly IMapper _mapper;
        public SaveFilmCommandHandler(IMapper mapper, ISavedFilmRepository savedFilmRepository, AuthBusinessRules authBusinessRules, FilmBusinessRules filmBusinessRules, IFilmDetailRepository filmDetailRepository, ITMDBApiClient tmdbApiClient)
        {
            _mapper = mapper;
            _savedFilmRepository = savedFilmRepository;
            _authBusinessRules = authBusinessRules;
            _filmBusinessRules = filmBusinessRules;
            _filmDetailRepository = filmDetailRepository;
            _tmdbApiClient = tmdbApiClient;
        }

        public async Task<CreatedSavedFilmDto> Handle(SaveFilmCommand request, CancellationToken cancellationToken)
        {

            await _authBusinessRules.CheckUserExistsById(request.UserId);
            await _filmBusinessRules.CheckIfUserSavedMaximumThreeFilmsToday(request.UserId);

            FilmDetail? foundFilmDetail = await _filmDetailRepository.GetAsync(x => x.Id == request.FilmId);
            if (foundFilmDetail is not null)
            {
                await _filmBusinessRules.CheckIfUserAlreadySavedThisFilm(request.UserId, request.FilmId, request.Status);

                SavedFilm? savedFilmOfUser = await _savedFilmRepository.GetAsync(
                    x => x.UserId == request.UserId &&
                    x.FilmId == request.FilmId
                );

                if (savedFilmOfUser is null)
                {
                    SavedFilm newSavedFilm = _mapper.Map<SavedFilm>(request);
                    SavedFilm addedSavedFilm = await _savedFilmRepository.AddAsync(newSavedFilm);
                    return _mapper.Map<CreatedSavedFilmDto>(addedSavedFilm);
                }
                else
                {
                    SavedFilm mappedSavedFilm = _mapper.Map<SavedFilm>(request);

                    SavedFilm updatedSavedFilm = await _savedFilmRepository.UpdateAsync(mappedSavedFilm);
                    return _mapper.Map<CreatedSavedFilmDto>(updatedSavedFilm);
                }

            }
            else
            {
                var fetchedFilm = await _tmdbApiClient.GetFilmByIdAsync(request.FilmId);

                List<FilmDetailGenre> filmDetailGenres = fetchedFilm.Genre_ids.Select((genreId) => new FilmDetailGenre()
                {
                    FilmDetailId = fetchedFilm.Id.ToString(),
                    GenreId = genreId.ToString()
                }).ToList();

                FilmDetail newFilmDetail = _mapper.Map<FilmDetail>(fetchedFilm);

                SavedFilm newSavedFilm = new SavedFilm()
                {
                    FilmId = newFilmDetail.Id,
                    Status = request.Status,
                    UserId = request.UserId
                };

                newFilmDetail.SavedFilms.Add(newSavedFilm);

                await _filmDetailRepository.AddAsync(newFilmDetail);

                return _mapper.Map<CreatedSavedFilmDto>(newSavedFilm);
            }



        }
    }

}