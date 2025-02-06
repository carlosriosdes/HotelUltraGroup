using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationDetailGuestConfiguration : IEntityTypeConfiguration<ReservationDetailGuest>
    {
        public void Configure(EntityTypeBuilder<ReservationDetailGuest> builder)
        {
            builder.ToTable("ReservationDetailGuests");

            builder.HasKey(rd => rd.Id);

            builder.Property(rd => rd.ReservationId)
                .IsRequired();

            builder.Property(rd => rd.GuestId)
                .IsRequired();

            builder.HasOne(rd => rd.Reservation)
                .WithMany(r => r.Guests)
                .HasForeignKey(rd => rd.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rd => rd.Guest)
                .WithMany(g => g.ReservationDetailGuests) 
                .HasForeignKey(rd => rd.GuestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
