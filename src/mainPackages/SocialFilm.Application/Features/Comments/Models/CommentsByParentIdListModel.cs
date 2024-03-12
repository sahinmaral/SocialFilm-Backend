using Core.Persistence.Paging;
using SocialFilm.Application.Features.Comments.Dtos;

namespace SocialFilm.Application.Features.Comments.Models;

public class CommentsByParentIdListModel : BasePageableModel
{
    public IList<CommentByParentIdDto> Items { get; set; }
}