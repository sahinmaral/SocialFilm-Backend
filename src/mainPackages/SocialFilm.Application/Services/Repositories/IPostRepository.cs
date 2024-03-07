using Core.Persistence.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Services.Repositories;

public interface IPostRepository : IAsyncRepository<Post>, IRepository<Post>
{
    // Task<Post?> GetByIdDetailedAsync(string postId, CancellationToken cancellationToken);
}