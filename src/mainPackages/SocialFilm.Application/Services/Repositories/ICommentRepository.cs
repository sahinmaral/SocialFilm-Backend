using Core.Persistence.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Services.Repositories;

public interface ICommentRepository : IAsyncRepository<Comment>, IRepository<Comment>
{
    //Task<Comment?> GetByIdDetailAsync(string commentId, CancellationToken cancellationToken);
}
