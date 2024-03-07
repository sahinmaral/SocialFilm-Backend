using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Infrastructure.Repositories;

public sealed class CommentRepository : EfRepositoryBase<Comment, AppDbContext>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    // public async Task<Comment?> GetByIdDetailAsync(string commentId, CancellationToken cancellationToken)
    // {
    //     return await _context
    //         .Set<Comment>()
    //         .Include(x => x.SubComments)
    //         .FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);
    // }
}