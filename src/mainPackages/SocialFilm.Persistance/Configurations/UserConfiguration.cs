using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialFilm.Persistance.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        
        var adminUser = new User
        {
            Id = "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
            FirstName = "Admin",
            LastName = "User",
            BirthDate = DateTime.Parse("1990-01-01"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = "aee6d18f-368f-4a34-8de7-b7aad7ce24f9",
            CreatedAt = DateTime.Now
        };
        
        var passwordHasher = new PasswordHasher<User>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Abc1234.");

        builder.HasData(adminUser);
    }
}


