using Core.Persistence.Repositories;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Infrastructure.Repositories;

public sealed class SavedFilmRepository : EfRepositoryBase<SavedFilm, AppDbContext>, ISavedFilmRepository
{
    public SavedFilmRepository(AppDbContext context) : base(context)
    {
    }

    // public override Task AddAsync(SavedFilm entity, CancellationToken cancellationToken = default)
    // {
    //     _context.Entry(entity.Film).State = EntityState.Unchanged;
    //     return base.AddAsync(entity, cancellationToken);
    // }

    // public override void Update(SavedFilm entity)
    // {
    //     _context.Entry(entity.Film).State = EntityState.Unchanged;
    //     base.Update(entity);
    // }

    public async Task<int> GetCountOfTodaySavedFilmsOfUserAsync(string userId)
    {
        DateTime currentTime = DateTime.Now;
        DateTime thresholdTime = currentTime.Subtract(TimeSpan.FromHours(24));

        var paginatedResult = await GetListAsync(
            x => x.UserId == userId && x.Status == SavedFilmStatus.WATCHED && ((x.UpdatedAt != null && x.UpdatedAt > thresholdTime) || x.CreatedAt > thresholdTime)
        );

        return paginatedResult.Count;
    }
}
