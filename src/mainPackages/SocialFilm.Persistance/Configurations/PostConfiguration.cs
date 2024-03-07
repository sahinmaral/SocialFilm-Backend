using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SocialFilm.Domain.Entities;

namespace SocialFilm.Persistance.Configurations;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.Id);

        builder.HasMany(p => p.PostPhotos)
            .WithOne(pf => pf.Post)
            .HasForeignKey(pf => pf.PostId);

        builder.HasMany(p => p.Comments)
            .WithOne()
            .HasForeignKey(c => c.PostId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}
