using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialFilm.Application.Services.Repositories;
using SocialFilm.Domain.Entities;
using SocialFilm.Persistance.Context;

namespace SocialFilm.Persistance.Repositories;

public sealed class PostRepository : EfRepositoryBase<Post, AppDbContext>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
    
    public new async Task<Post> AddAsync(Post entity)
    {
        foreach (var postPhoto in entity.PostPhotos)
        {
            Context.Entry(postPhoto).State = EntityState.Added;
        }
        var newPost = await base.AddAsync(entity);
        return newPost;
    }
    
}
