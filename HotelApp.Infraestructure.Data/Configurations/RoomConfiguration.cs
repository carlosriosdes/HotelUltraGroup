using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Location)
                .IsRequired() 
                .HasMaxLength(50);

            builder.Property(r => r.BasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.Tax)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms) 
                .HasForeignKey(r => r.HotelId) 
                .OnDelete(DeleteBehavior.Cascade); 


            builder.HasOne(r => r.RoomType)
                .WithMany() 
                .HasForeignKey(r => r.IdRoomType) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => r.HotelId);
        }
    }
}
