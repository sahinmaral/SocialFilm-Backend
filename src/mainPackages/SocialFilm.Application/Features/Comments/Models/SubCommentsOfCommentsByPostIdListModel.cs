using Core.Persistence.Paging;
using SocialFilm.Application.Features.Comments.Dtos;

namespace SocialFilm.Application.Features.Comments.Models;

public class SubCommentsOfCommentsByPostIdListModel : BasePageableModel
{
    public IList<SubCommentsOfCommentsByPostIdDto> Items { get; set; }
}