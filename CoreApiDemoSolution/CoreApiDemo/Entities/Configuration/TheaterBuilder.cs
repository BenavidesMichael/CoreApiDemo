using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class TheaterBuilder : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> theater)
        {
            theater.HasKey(x => x.Id);

            theater.HasOne(t => t.TheaterOffer)
                    .WithOne(i => i.Theater)
                    .HasForeignKey<TheaterOffer>(t => t.TheatherId);
            
            theater.Property(n => n.Name).IsRequired();
        }
    }
}
