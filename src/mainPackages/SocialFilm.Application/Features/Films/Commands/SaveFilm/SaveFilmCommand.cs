using AutoMapper;

using MediatR;
using SocialFilm.Application.Features.Films.Rules;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Services.ApiClients;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;
using Core.Application.Pipelines.Authorization;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Application.Features.Films.Commands.SaveFilm;

public partial class SaveFilmCommand : IRequest<CreatedSavedFilmDto>, ISecuredRequest
{
    public string FilmId { get; init; }
    public string UserId { get; init; }
    public SavedFilmStatus Status { get; init; }
    public string[] Roles => new[] { "User" };

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
                    newSavedFilm.FilmId = request.FilmId;
                    
                    await _savedFilmRepository.AddAsync(newSavedFilm);
                    
                    SavedFilm addedSavedFilm = (await _savedFilmRepository.GetDetailedAsync(
                        predicate: x => x.Id == newSavedFilm.Id,
                        include: qsf =>                     
                            qsf.Include(sf => sf.Film)
                                .ThenInclude(fd => fd.FilmDetailGenres)
                                .ThenInclude(fdg => fdg.Genre),
                        enableTracking: false
                    ))!;

                    return _mapper.Map<CreatedSavedFilmDto>(addedSavedFilm);
                }
                else
                {
                    savedFilmOfUser.Status = request.Status;
                    await _savedFilmRepository.UpdateAsync(savedFilmOfUser);
                    
                    SavedFilm updatedSavedFilm = (await _savedFilmRepository.GetDetailedAsync(
                        predicate: x => x.Id == savedFilmOfUser.Id,
                        include: qsf =>                     
                            qsf.Include(sf => sf.Film)
                                .ThenInclude(fd => fd.FilmDetailGenres)
                                .ThenInclude(fdg => fdg.Genre),
                        enableTracking: false
                    ))!;
                
                    return _mapper.Map<CreatedSavedFilmDto>(updatedSavedFilm);   
                }

            }
            else
            {
                var fetchedFilm = await _tmdbApiClient.GetFilmByIdAsync(request.FilmId);

                FilmDetail newFilmDetail = _mapper.Map<FilmDetail>(fetchedFilm);
                await _filmDetailRepository.AddAsync(newFilmDetail);
                
                SavedFilm newSavedFilm = new SavedFilm()
                {
                    Film = newFilmDetail,
                    FilmId = newFilmDetail.Id,
                    Status = request.Status,
                    UserId = request.UserId
                };
                
                await _savedFilmRepository.AddAsync(newSavedFilm);
                
                SavedFilm addedSavedFilm = (await _savedFilmRepository.GetDetailedAsync(
                    predicate: x => x.Id == newSavedFilm.Id,
                    include: qsf =>                     
                        qsf.Include(sf => sf.Film)
                            .ThenInclude(fd => fd.FilmDetailGenres)
                            .ThenInclude(fdg => fdg.Genre),
                    enableTracking: false
                ))!;
                
                return _mapper.Map<CreatedSavedFilmDto>(addedSavedFilm);
            }
        }
    }

}