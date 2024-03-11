using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialFilm.Domain.Entities;

namespace SocialFilm.Persistance.Configurations;

public sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name);

        builder.HasData(
            new Genre()
            {
                Id = "28",
                Name = "Action",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "12",
                Name = "Adventure",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "16",
                Name = "Animation",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "35",
                Name = "Comedy",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "80",
                Name = "Crime",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "99",
                Name = "Documentary",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "18",
                Name = "Drama",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "10751",
                Name = "Family",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "14",
                Name = "Fantasy",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "36",
                Name = "History",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "27",
                Name = "Horror",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "10402",
                Name = "Music",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "9648",
                Name = "Mystery",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "10749",
                Name = "Romance",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "878",
                Name = "Science Fiction",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "10770",
                Name = "TV Movie",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "53",
                Name = "Thriller",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "10752",
                Name = "War",
                CreatedAt = DateTime.Now
            },
            new Genre()
            {
                Id = "37",
                Name = "Western",
                CreatedAt = DateTime.Now
            }
        );
    }
}