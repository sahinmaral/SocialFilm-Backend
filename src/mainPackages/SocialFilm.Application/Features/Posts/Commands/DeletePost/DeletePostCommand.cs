using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Posts.Dtos;
using SocialFilm.Application.FileStorage;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Posts.Commands.DeletePost;

public class DeletePostCommand : IRequest<DeletedPostDto>, ISecuredRequest
{
    public string Id { get; set; }
    public string[] Roles => new[] { "User", "Admin" };

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletedPostDto>
    {
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(
            IPostRepository postRepository,
            ICloudinaryService cloudinaryService, 
            IMapper mapper)
        {
            _postRepository = postRepository;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
        }

        public async Task<DeletedPostDto> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Post? foundPost = await _postRepository
                .GetDetailedAsync(
                    predicate: x => x.Id == request.Id,
                    include: qf =>
                        qf.Include(fd => fd.PostPhotos),
                    enableTracking: false
                );

            if (foundPost is null)
                throw new BusinessException("Post could not found");

            //FIX: Fotograflardan bazilari eger bulunmazsa bu islemin iptal edilmesi gerekir. Transaction gerekebilir.
            //FIX: Veritabanindan silerken hata alirsak fotograf silme islemlerinin geri alinmasi gerekir. Transaction gerekebilir.

            var deleteTasks = foundPost.PostPhotos.Select(pf =>
                _cloudinaryService.DeleteImageAsync(
                    ConvertPhotoPathToPublicId(pf.PhotoPath), 
                    cancellationToken));
            var deletedImageTaskResult = await Task.WhenAll(deleteTasks);

            var deletedPost = _postRepository.Delete(foundPost);

            return _mapper.Map<DeletedPostDto>(deletedPost);
        }

        private string ConvertPhotoPathToPublicId(string photoPath)
        {
            string modifiedString = photoPath.Replace("image/upload/", "");
            int dotIndex = modifiedString.IndexOf('.');
            modifiedString = modifiedString.Substring(0, dotIndex);
            return modifiedString;
        }
    }

    
}