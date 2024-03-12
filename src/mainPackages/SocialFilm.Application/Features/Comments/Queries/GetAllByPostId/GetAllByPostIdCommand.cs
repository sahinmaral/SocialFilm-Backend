using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Comments.Models;
using SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;
using SocialFilm.Application.Features.Comments.Rules;
using SocialFilm.Application.Features.Posts.Rules;
using SocialFilm.Application.Services.Repositories;

namespace SocialFilm.Application.Features.Comments.Queries.GetAllByPostId;

public class GetAllByPostIdCommand : IRequest<CommentsByPostIdListModel>
{
    public string Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;

    public class GetAllByPostIdCommandHandler : IRequestHandler<GetAllByPostIdCommand, CommentsByPostIdListModel>
    {
        private readonly IMapper _mapper;
        private readonly PostBusinessRules _postBusinessRules;
        private readonly ICommentRepository _commentRepository;

        public GetAllByPostIdCommandHandler(ICommentRepository commentRepository, IMapper mapper, PostBusinessRules postBusinessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<CommentsByPostIdListModel> Handle(GetAllByPostIdCommand request, CancellationToken cancellationToken)
        {
            await _postBusinessRules.CheckPostExistsById(request.Id);

            var parentComments = await _commentRepository.GetListAsync(
                predicate: c => c.PostId == request.Id && c.ParentCommentId == null && c.DeletedAt == null,
                include: qc => qc.Include(c => c.User),
                orderBy: qc => qc.OrderByDescending(c => c.CreatedAt)
            );

            var mappedParentComments = _mapper.Map<CommentsByPostIdListModel>(parentComments);

            foreach (var parentComment in mappedParentComments.Items)
            {
                var subComments = _commentRepository
                    .GetList(
                        predicate: c => c.ParentCommentId == parentComment.Id && c.DeletedAt == null,
                        include: qc => qc.Include(c => c.User),
                        orderBy: qc => qc.OrderByDescending(c => c.CreatedAt)
                    );
            
                var mappedSubComments = _mapper.Map<SubCommentsOfCommentsByPostIdListModel>(subComments);
            
                parentComment.SubComments = mappedSubComments;
            }

            return mappedParentComments;
        }
    }
}