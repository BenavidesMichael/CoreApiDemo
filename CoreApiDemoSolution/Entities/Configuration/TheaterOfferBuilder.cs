using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class TheaterOfferBuilder : IEntityTypeConfiguration<TheaterOffer>
    {
        public void Configure(EntityTypeBuilder<TheaterOffer> theaterOffer)
        {
            theaterOffer.HasKey(t=> t.Id);

            theaterOffer.Property(t => t.Discount)
                            .HasPrecision(5, 2);
        }
    }
}
