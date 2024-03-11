using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Features.Films.Rules;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Application.Features.Posts.Rules;
using SocialFilm.Application.FileStorage;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<CreatedPostDto>
{
    public string[] Roles => new[] { "User" };
    public string UserId { get; init; }
    public string FilmId { get; init; }
    public string Content { get; init; }
    public List<IFormFile> Photos { get; set; }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostDto>
    {
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly FilmBusinessRules _filmBusinessRules;
        private readonly PostBusinessRules _postBusinessRules;
        private readonly IPostRepository _postRepository;
        private readonly IFilmDetailRepository _filmDetailRepository;

        public CreatePostCommandHandler(IPostRepository postRepository,
            PostBusinessRules postBusinessRules,
            FilmBusinessRules filmBusinessRules,
            AuthBusinessRules authBusinessRules,
            ICloudinaryService cloudinaryService,
            IMapper mapper, 
            IFilmDetailRepository filmDetailRepository)
        {
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
            _filmBusinessRules = filmBusinessRules;
            _authBusinessRules = authBusinessRules;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
            _filmDetailRepository = filmDetailRepository;
        }

        public async Task<CreatedPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            #region Business rules

            await _authBusinessRules.CheckUserExistsById(request.UserId);
            await _filmBusinessRules.CheckFilmExistsById(request.FilmId);
            await _postBusinessRules.CheckIfUserWatchedFilmAboutToPost(request.UserId, request.FilmId);

            #endregion

            //FIX: Eger veritabaninda bir problem olursa yuklenen resimlerin silinmesi gerekir.
            var uploadTasks = request.Photos.Select(file => _cloudinaryService.UploadImageAsync(file, cancellationToken));
            var uploadedImageResults = await Task.WhenAll(uploadTasks);

            var uploadedImageUrls = uploadedImageResults.Select(ir => $"{ir.FullyQualifiedPublicId}.{ir.Format}").ToList();

            Post newPost = _mapper.Map<Post>(request);
            uploadedImageUrls.ForEach((ir) =>
            {
                newPost.PostPhotos.Add(new PostPhoto()
                {
                    PhotoPath = ir
                });
            });

            await _postRepository.AddAsync(newPost);

            var addedPost = (await _postRepository.GetDetailedAsync(
                include: qp => qp.Include(p => p.PostPhotos),
                predicate: x => x.Id == newPost.Id,
                enableTracking: false
            ))!;
            
            
            FilmDetail addedPostFilmDetail = (await _filmDetailRepository.GetDetailedAsync(
                predicate: x => x.Id == addedPost.FilmId,
                include: qf =>                     
                        qf.Include(fd => fd.FilmDetailGenres)
                        .ThenInclude(fdg => fdg.Genre),
                enableTracking: false
            ))!;

            var mappedPost = _mapper.Map<CreatedPostDto>(addedPost);
            mappedPost.FilmDetail = _mapper.Map<CreatedPostFilmDetailDto>(addedPostFilmDetail);
            
            return mappedPost;
        }
    }
}