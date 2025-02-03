using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(g => g.Email)
                .HasMaxLength(100);

            builder.Property(g => g.PhoneNumber)
                .HasMaxLength(20);

            builder.HasOne(g => g.DocumentType)
                .WithMany(dt => dt.Guests)
                .HasForeignKey(g => g.IdDocumentType)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
