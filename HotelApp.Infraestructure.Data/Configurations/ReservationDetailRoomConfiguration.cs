using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationDetailRoomConfiguration : IEntityTypeConfiguration<ReservationDetailRoom>
    {
        public void Configure(EntityTypeBuilder<ReservationDetailRoom> builder)
        {
            builder.ToTable("ReservationDetailRooms");

            builder.HasKey(rd => rd.Id);

            builder.Property(rd => rd.ReservationId)
                .IsRequired();

            builder.Property(rd => rd.RoomId)
                .IsRequired();

            builder.HasOne(rd => rd.Reservation)
                   .WithMany(r => r.Rooms)  
                   .HasForeignKey(rd => rd.ReservationId)
                   .OnDelete(DeleteBehavior.Cascade);  


            builder.HasOne(rd => rd.Room)
                   .WithMany(g => g.ReservationDetailRooms)  
                   .HasForeignKey(rd => rd.RoomId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
