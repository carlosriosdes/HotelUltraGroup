using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.Address)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.City)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.IsActive)
                   .HasDefaultValue(true);
        }
    }
}
