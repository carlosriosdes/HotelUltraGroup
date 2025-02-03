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
                .WithMany()
                .HasForeignKey(rdr => rdr.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rdr => rdr.Room)
                .WithMany()
                .HasForeignKey(rdr => rdr.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
