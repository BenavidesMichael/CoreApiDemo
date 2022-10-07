using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class GenrerBuilder : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> genrer)
        {
            //genrer.ToTable(name: "Genrer", schema: "Movies");
            genrer.HasKey(x => x.Id);

            genrer.Property(n => n.Name)
                    .IsRequired()
                    .HasMaxLength(150);
        }
    }
}
