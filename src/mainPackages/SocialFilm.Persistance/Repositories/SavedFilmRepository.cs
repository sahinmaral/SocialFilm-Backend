using System.Linq.Expressions;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Domain.Enums;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Persistance.Repositories;

public sealed class SavedFilmRepository : EfRepositoryBase<SavedFilm, AppDbContext>, ISavedFilmRepository
{
    private readonly AppDbContext _context;

    public SavedFilmRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<int> GetCountOfTodaySavedFilmsOfUserAsync(string userId)
    {
        DateTime currentTime = DateTime.Now;
        DateTime thresholdTime = currentTime.Subtract(TimeSpan.FromHours(24));

        var paginatedResult = await GetListAsync(
            x => x.UserId == userId && x.Status == SavedFilmStatus.WATCHED && ((x.UpdatedAt != null && x.UpdatedAt > thresholdTime) || x.CreatedAt > thresholdTime)
        );

        return paginatedResult.Count;
    }

    public async Task<SavedFilm?> GetDetailedAsync(Expression<Func<SavedFilm, bool>> predicate)
    {
        var savedFilm = await Context.Set<SavedFilm>()
            .AsNoTracking() 
            .Include(sf => sf.Film)
            .ThenInclude(fd => fd.FilmDetailGenres)
            .ThenInclude(fdg => fdg.Genre)
            .FirstOrDefaultAsync(predicate);

        return savedFilm;
    }   
}
