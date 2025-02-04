using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationDetailGuestConfiguration : IEntityTypeConfiguration<ReservationDetailGuest>
    {
        public void Configure(EntityTypeBuilder<ReservationDetailGuest> builder)
        {
            builder.HasKey(rdg => rdg.Id);

            builder.HasOne(rdg => rdg.Reservation)
                .WithMany(r => r.Guests)  
                .HasForeignKey(rdg => rdg.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rdg => rdg.Guest)
                .WithMany(g => g.ReservationDetailGuests)  
                .HasForeignKey(rdg => rdg.GuestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
