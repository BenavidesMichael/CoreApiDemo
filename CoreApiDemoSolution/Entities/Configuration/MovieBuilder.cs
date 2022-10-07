using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class MovieBuilder : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> movie)
        {
            movie.HasKey(m => m.Id);

            movie.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(250);

            movie.Property(m => m.UrlImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);
        }
    }
}
