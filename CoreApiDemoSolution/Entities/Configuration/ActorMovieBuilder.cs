using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class ActorMovieBuilder : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> actorMovie)
        {
            // n-n
            actorMovie.HasKey(foreignKeys => new
            {
                foreignKeys.MovieId,
                foreignKeys.ActorId
            });

            actorMovie.Property(am => am.Character)
                        .HasMaxLength(150);
        }
    }
}
