using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Features.Comments.Models;
using SocialFilm.Application.Features.Comments.Rules;
using SocialFilm.Application.Services.Repositories;

namespace SocialFilm.Application.Features.Comments.Queries.GetAllByParentCommentId;

public class GetAllByParentIdCommand : IRequest<CommentsByParentIdListModel>
{
    public string Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    
    public class GetAllByParentIdCommandHandler : IRequestHandler<GetAllByParentIdCommand, CommentsByParentIdListModel>
    {
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _commentBusinessRules;
        private readonly ICommentRepository _commentRepository;

        public GetAllByParentIdCommandHandler(ICommentRepository commentRepository, CommentBusinessRules commentBusinessRules, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
            _mapper = mapper;
        }

        public async Task<CommentsByParentIdListModel> Handle(GetAllByParentIdCommand request, CancellationToken cancellationToken)
        {
            await _commentBusinessRules.CheckCommentExistsById(request.Id);

            var subComments = await _commentRepository
                .GetListAsync(
                    predicate: c => c.ParentCommentId == request.Id,
                    include: qc => qc.Include(c => c.User),
                    orderBy: qc => qc.OrderByDescending(c => c.CreatedAt),
                    cancellationToken: cancellationToken,
                    index: request.PageNumber - 1,
                    size: request.PageSize
                );

            return _mapper.Map<CommentsByParentIdListModel>(subComments);
        }
    }
}