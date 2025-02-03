using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.TotalPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.EmergencyContactName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.EmergencyContactPhone)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(r => r.Hotel)
                .WithMany()
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
