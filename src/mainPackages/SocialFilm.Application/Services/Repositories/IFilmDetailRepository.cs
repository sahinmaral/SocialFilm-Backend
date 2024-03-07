using Core.Persistence.Repositories;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Services.Repositories;

public interface IFilmDetailRepository : IAsyncRepository<FilmDetail>, IRepository<FilmDetail>
{
}
