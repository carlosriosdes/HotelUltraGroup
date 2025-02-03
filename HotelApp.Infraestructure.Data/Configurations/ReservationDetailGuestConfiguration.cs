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
                .WithMany()
                .HasForeignKey(rdg => rdg.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rdg => rdg.Guest)
                .WithMany()
                .HasForeignKey(rdg => rdg.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
