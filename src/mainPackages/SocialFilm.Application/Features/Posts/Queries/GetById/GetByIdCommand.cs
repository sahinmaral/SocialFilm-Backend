using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Application.Services.Repositories;

namespace SocialFilm.Application.Features.Posts.Queries.GetById;

public class GetByIdCommand : IRequest<PostByIdDto>
{
    public string Id { get; set; }

    public class GetByIdCommandHandler : IRequestHandler<GetByIdCommand, PostByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IFilmDetailRepository _filmDetailRepository;

        public GetByIdCommandHandler(IPostRepository postRepository, IMapper mapper, IFilmDetailRepository filmDetailRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _filmDetailRepository = filmDetailRepository;
        }

        public async Task<PostByIdDto> Handle(GetByIdCommand request, CancellationToken cancellationToken)
        {
            var foundPost = await _postRepository.GetDetailedAsync(
                include: qp => qp
                    .Include(p => p.PostPhotos)
                    .Include(p => p.Film)
                    .ThenInclude(fd => fd.FilmDetailGenres)
                    .ThenInclude(fdg => fdg.Genre),
                predicate: x => x.Id == request.Id,
                enableTracking: false
            );

            if (foundPost is null)
                throw new EntityNotFoundException("Post could not found");

            return _mapper.Map<PostByIdDto>(foundPost);
        }
    }
}