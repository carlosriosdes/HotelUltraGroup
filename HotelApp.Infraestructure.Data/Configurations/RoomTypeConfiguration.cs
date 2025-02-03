﻿using HotelApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Infraestructure.Persistence.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(rt => rt.Description)
                .HasMaxLength(500);
        }
    }
}
