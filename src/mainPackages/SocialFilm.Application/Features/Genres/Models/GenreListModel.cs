using Core.Persistence.Paging;
using SocialFilm.Application.Features.Genres.Dtos;

namespace SocialFilm.Application.Features.Genres.Models;

public class GenreListModel : BasePageableModel
{
    public IList<GenreListDto> Items { get; set; }
}