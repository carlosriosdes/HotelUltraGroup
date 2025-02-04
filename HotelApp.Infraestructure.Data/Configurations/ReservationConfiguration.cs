using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.CheckInDate)
                .IsRequired();

            builder.Property(r => r.CheckOutDate)
                .IsRequired();

            builder.Property(r => r.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.EmergencyContactName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.EmergencyContactPhone)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Rooms)
                .WithOne(rd => rd.Reservation)
                .HasForeignKey(rd => rd.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Guests)
                .WithOne(rg => rg.Reservation)
                .HasForeignKey(rg => rg.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
