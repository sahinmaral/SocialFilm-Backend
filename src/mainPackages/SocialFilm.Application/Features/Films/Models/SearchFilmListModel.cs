using Core.Persistence.Paging;
using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Application.Features.Films.Models;

public class SearchFilmListModel : BasePageableModel
{
    public IList<SearchFilmListDto> Items { get; set; }
}
