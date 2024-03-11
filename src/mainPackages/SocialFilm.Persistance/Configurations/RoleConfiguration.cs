using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialFilm.Persistance.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(x => x.Id);

        builder.HasData(
            new Role(){Name = "Admin", NormalizedName = "ADMIN", Id = "4de444e7-f5e1-4e43-be6b-badd43780c88"},
            new Role(){Name = "User", NormalizedName = "USER", Id = "ca739d3c-f1ed-48ab-aa84-18be21d88601"}
            );
    }
}
