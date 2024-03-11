using System.Linq.Expressions;
using Core.Persistence.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Services.Repositories;

public interface ISavedFilmRepository : IAsyncRepository<SavedFilm>, IRepository<SavedFilm>
{
    public Task<int> GetCountOfTodaySavedFilmsOfUserAsync(string userId);
    Task<SavedFilm?> GetDetailedAsync(Expression<Func<SavedFilm, bool>> predicate);
}
