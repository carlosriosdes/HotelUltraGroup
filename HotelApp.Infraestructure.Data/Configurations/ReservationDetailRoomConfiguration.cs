using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationDetailRoomConfiguration : IEntityTypeConfiguration<ReservationDetailRoom>
    {
        public void Configure(EntityTypeBuilder<ReservationDetailRoom> builder)
        {
            builder.HasKey(rdr => rdr.Id);

            builder.HasOne(rdr => rdr.Reservation)
                .WithMany(r => r.Rooms)
                .HasForeignKey(rdr => rdr.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rdr => rdr.Room)
                .WithMany(g => g.ReservationDetailRooms)
                .HasForeignKey(rdr => rdr.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
