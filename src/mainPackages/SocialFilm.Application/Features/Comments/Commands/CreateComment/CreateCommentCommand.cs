using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Features.Comments.Dtos;
using SocialFilm.Application.Features.Comments.Rules;
using SocialFilm.Application.Features.Posts.Rules;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Comments.Commands.CreateComment;

public class CreateCommentCommand : IRequest<CreatedCommentDto>
{
    public string PostId { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    public string? ParentCommentId { get; set; }
    
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly CommentBusinessRules _commentBusinessRules;
        private readonly PostBusinessRules _postBusinessRules;

        public CreateCommentCommandHandler(CommentBusinessRules commentBusinessRules,
            PostBusinessRules postBusinessRules,
            ICommentRepository commentRepository,
            IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _commentBusinessRules = commentBusinessRules;
            _postBusinessRules = postBusinessRules;
            _commentRepository = commentRepository;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.CheckUserExistsById(request.UserId);
            await _postBusinessRules.CheckPostExistsById(request.PostId);

            if (request.ParentCommentId is not null)
            {
                await _commentBusinessRules.CheckCommentExistsById(request.ParentCommentId);
            }

            Comment newComment = _mapper.Map<Comment>(request);
            await _commentRepository.AddAsync(newComment);

            return _mapper.Map<CreatedCommentDto>(newComment);
        }
    }
}