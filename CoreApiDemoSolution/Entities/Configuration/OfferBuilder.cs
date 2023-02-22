using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class OfferBuilder : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> offer)
        {
            offer.HasKey(t=> t.Id);

            offer.Property(t => t.Discount)
                            .HasPrecision(5, 2);
        }
    }
}
