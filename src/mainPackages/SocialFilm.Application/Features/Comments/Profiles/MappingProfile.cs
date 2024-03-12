using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using SocialFilm.Application.Features.Comments.Commands.CreateComment;
using SocialFilm.Application.Features.Comments.Dtos;
using SocialFilm.Application.Features.Comments.Models;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Application.Features.Comments.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IPaginate<Comment>, CommentsByParentIdListModel>();
        CreateMap<IPaginate<Comment>, CommentsByPostIdListModel>();
        CreateMap<IPaginate<Comment>, SubCommentsOfCommentsByPostIdListModel>();

        CreateMap<Comment, CommentByParentIdDto>();
        CreateMap<Comment, CommentByPostIdDto>()
            .ForMember(dest => dest.SubComments, opt => opt.Ignore());
        CreateMap<Comment, SubCommentsOfCommentsByPostIdDto>();

        CreateMap<User, CommentByParentIdUserDto>();
        CreateMap<User, CommentByPostIdUserDto>();
        CreateMap<User, SubCommentsOfCommentsByPostIdUserDto>();

        CreateMap<CreateCommentCommand, Comment>();
            
        CreateMap<Comment, CreatedCommentDto>();
        CreateMap<Comment, DeletedCommentDto>();
    }
}