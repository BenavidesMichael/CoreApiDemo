using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApiDemo.Entities.Configuration
{
    public class RoomTheatreBuilder : IEntityTypeConfiguration<RoomTheatre>
    {
        public void Configure(EntityTypeBuilder<RoomTheatre> roomTheater)
        {
            roomTheater.HasKey(x => x.Id);

            roomTheater.Property(n => n.Price)
                               .IsRequired()
                               .HasPrecision(precision: 9, scale: 2);

            roomTheater.Property(n => n.TypeRoomTheatre)
                        .HasDefaultValue(TypeRoomTheatre.DeuxD);
        }
    }
}
