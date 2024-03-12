using AutoMapper;
using MediatR;
using SocialFilm.Application.Features.Comments.Dtos;
using SocialFilm.Application.Features.Comments.Rules;
using SocialFilm.Application.Services.Repositories;

namespace SocialFilm.Application.Features.Comments.Commands.DeleteComment;

public class DeleteCommentCommand : IRequest<DeletedCommentDto>
{
    public string Id { get; set; }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeletedCommentDto>
    {
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository, CommentBusinessRules commentBusinessRules, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedCommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentBusinessRules.CheckCommentExistsById(request.Id);

            var deletedComment = (await _commentRepository.GetAsync(c => c.Id == request.Id))!;
            deletedComment.DeletedAt = DateTime.Now;

            await _commentRepository.UpdateAsync(deletedComment);

            return _mapper.Map<DeletedCommentDto>(deletedComment);
        }
    }
}