using Core.Persistence.Paging;
using SocialFilm.Application.Features.Comments.Dtos;

namespace SocialFilm.Application.Features.Comments.Models;

public class CommentsByPostIdListModel : BasePageableModel
{
    public IList<CommentByPostIdDto> Items { get; set; }
}