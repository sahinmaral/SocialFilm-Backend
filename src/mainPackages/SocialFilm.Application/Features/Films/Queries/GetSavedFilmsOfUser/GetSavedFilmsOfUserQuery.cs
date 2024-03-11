using AutoMapper;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Enums;

namespace SocialFilm.Application.Features.Films.Queries.GetSavedFilmsOfUser;

public class GetSavedFilmsOfUserQuery : IRequest<SavedFilmsOfUserListModel>
{
    public string UserId { get; set; }
    public SavedFilmStatus SavedFilmStatus { get; set; }
    
    public class GetSavedFilmsOfUserQueryHandler : IRequestHandler<GetSavedFilmsOfUserQuery, SavedFilmsOfUserListModel>
    {
        private readonly ISavedFilmRepository _savedFilmRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public GetSavedFilmsOfUserQueryHandler(ISavedFilmRepository savedFilmRepository, AuthBusinessRules authBusinessRules, IMapper mapper)
        {
            _savedFilmRepository = savedFilmRepository;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
        }

        public async Task<SavedFilmsOfUserListModel> Handle(GetSavedFilmsOfUserQuery request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.CheckUserExistsById(request.UserId);

            Dynamic dynamicFilter = new Dynamic
            {
                Filter = new Filter
                {
                    Field = "UserId",
                    Operator = "eq",
                    Value = request.UserId,
                    Logic = "&&",
                    Filters = new List<Filter>()
                    {
                        new()
                        {
                            Field = "Status",
                            Operator = "eq",
                            Value = request.SavedFilmStatus.ToString(),
                        }
                    }
                }
            };
            
            var savedFilmsOfUser = 
                await _savedFilmRepository.GetListByDynamicAsync(
                    dynamicFilter,
                    orderBy: qsf => qsf.OrderByDescending(x => x.CreatedAt),
                include: qsf => qsf
                    .Include(sf => sf.Film)
                    .ThenInclude(fd => fd.FilmDetailGenres)
                    .ThenInclude(fdg => fdg.Genre)
                );
            
            SavedFilmsOfUserListModel savedFilmsOfUserListModel = _mapper.Map<SavedFilmsOfUserListModel>(savedFilmsOfUser);

            return savedFilmsOfUserListModel;
        }
    }
}