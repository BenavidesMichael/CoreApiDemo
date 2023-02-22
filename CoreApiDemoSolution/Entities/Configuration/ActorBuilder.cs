using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class ActorBuilder : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> actor)
        {
            actor.HasKey(x => x.Id);

            actor.Property(n => n.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            actor.Property(n => n.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
