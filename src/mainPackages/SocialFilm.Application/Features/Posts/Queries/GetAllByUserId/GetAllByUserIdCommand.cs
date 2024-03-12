using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Features.Films.Dtos;
using SocialFilm.Application.Features.Films.Models;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Application.Services.Repositories;

namespace SocialFilm.Application.Features.Posts.Queries.GetAllByUserId;

public class GetAllByUserIdCommand : IRequest<PostsByUserIdListModel>
{
    public string UserId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 15;

    public class GetAllByUserIdCommandHandler : IRequestHandler<GetAllByUserIdCommand, PostsByUserIdListModel>
    {
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IPostRepository _postRepository;
        private readonly IFilmDetailRepository _filmDetailRepository;

        public GetAllByUserIdCommandHandler(AuthBusinessRules authBusinessRules, IPostRepository postRepository, IMapper mapper, IFilmDetailRepository filmDetailRepository)
        {
            _authBusinessRules = authBusinessRules;
            _postRepository = postRepository;
            _mapper = mapper;
            _filmDetailRepository = filmDetailRepository;
        }

        public async Task<PostsByUserIdListModel> Handle(GetAllByUserIdCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.CheckUserExistsById(request.UserId);
            
            var postsOfUser = await _postRepository.GetListAsync(
                include: qp => qp
                    .Include(p => p.PostPhotos)
                    .Include(p => p.Film)
                    .ThenInclude(fd => fd.FilmDetailGenres)
                    .ThenInclude(fdg => fdg.Genre),
                predicate: x => x.UserId == request.UserId,
                orderBy: qp => qp.OrderByDescending(p => p.CreatedAt),
                enableTracking: false,
                size: request.PageSize,
                index: request.PageNumber - 1
            );

            var mappedPostsOfUser = _mapper.Map<PostsByUserIdListModel>(postsOfUser);
            
            return mappedPostsOfUser;
        }
    }
}