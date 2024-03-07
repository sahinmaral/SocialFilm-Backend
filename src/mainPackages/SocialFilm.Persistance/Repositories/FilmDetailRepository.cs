using Core.Persistence.Repositories;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Infrastructure.Repositories;

public sealed class FilmDetailRepository : EfRepositoryBase<FilmDetail, AppDbContext>, IFilmDetailRepository
{
    public FilmDetailRepository(AppDbContext context) : base(context)
    {
    }
}

