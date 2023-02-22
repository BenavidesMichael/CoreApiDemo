using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class RoomBuilder : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> room)
        {
            room.HasKey(x => x.Id);

            room.Property(n => n.Price)
                               .IsRequired()
                               .HasPrecision(precision: 9, scale: 2);

            room.Property(n => n.RoomType)
                        .HasDefaultValue(RoomType.DeuxD);
        }
    }
}
