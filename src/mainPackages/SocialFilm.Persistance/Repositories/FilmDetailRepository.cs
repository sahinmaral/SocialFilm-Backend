using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Persistance.Repositories;

public sealed class FilmDetailRepository : EfRepositoryBase<FilmDetail, AppDbContext>, IFilmDetailRepository
{
    public FilmDetailRepository(AppDbContext context) : base(context)
    {
    }

    public new async Task<FilmDetail> AddAsync(FilmDetail entity)
    {
        foreach (var filmDetailGenre in entity.FilmDetailGenres)
        {
            Context.Entry(filmDetailGenre).State = EntityState.Added;
        }
        var newFilmDetail = await base.AddAsync(entity);
        return newFilmDetail;
    }
}

