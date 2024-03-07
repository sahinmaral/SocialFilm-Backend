using Core.Persistence.Repositories;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Infrastructure.Repositories;

public sealed class GenreRepository : EfRepositoryBase<Genre, AppDbContext>, IGenreRepository
{
    public GenreRepository(AppDbContext context) : base(context)
    {
    }
}
