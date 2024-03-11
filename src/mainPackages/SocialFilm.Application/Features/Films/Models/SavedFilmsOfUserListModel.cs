using Core.Persistence.Paging;
using SocialFilm.Application.Features.Films.Dtos;

namespace SocialFilm.Application.Features.Films.Models;

public class SavedFilmsOfUserListModel : BasePageableModel
{
    public IList<SavedFilmsOfUserDto> Items { get; set; }
}