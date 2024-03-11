using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialFilm.Persistance.Configurations;

public sealed class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.ToTable("UserRoles");

        builder.HasData(
            new IdentityUserRole<string>()
            {
                UserId = "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
                RoleId = "4de444e7-f5e1-4e43-be6b-badd43780c88",
            }
        );
    }
}