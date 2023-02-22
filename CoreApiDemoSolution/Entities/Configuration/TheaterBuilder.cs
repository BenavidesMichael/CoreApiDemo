using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class TheaterBuilder : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> theater)
        {
            theater.HasKey(x => x.Id);

            theater.HasOne(t => t.Offer)
                    .WithOne(i => i.Theater)
                    .HasForeignKey<Offer>(t => t.TheaterId);
            
            theater.Property(n => n.Name).IsRequired();
        }
    }
}
