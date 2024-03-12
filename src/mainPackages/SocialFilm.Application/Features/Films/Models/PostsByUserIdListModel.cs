using Core.Persistence.Paging;
using SocialFilm.Application.Features.Posts.Dtos;

namespace SocialFilm.Application.Features.Films.Models;

public class PostsByUserIdListModel : BasePageableModel
{
    public IList<PostByUserIdDto> Items { get; set; }
}
