using Core.Persistence.Repositories;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Infrastructure.Repositories;

public sealed class PostRepository : EfRepositoryBase<Post, AppDbContext>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    // public async Task<Post?> GetByIdDetailedAsync(string postId, CancellationToken cancellationToken)
    // {
    //     return await _context.Set<Post>()
    //         .Include(x => x.PostPhotos)
    //         .SingleOrDefaultAsync(x => x.Id == postId, cancellationToken);
    // }

}
