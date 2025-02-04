﻿// <auto-generated />
using System;
using HotelApp.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelApp.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(HotelUltraGroupContext))]
    partial class HotelUltraGroupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelApp.Domain.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDocumentType")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdDocumentType");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Hotels", (string)null);
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmergencyContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyContactPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Reservations", (string)null);
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.ReservationDetailGuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationDetailGuests");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.ReservationDetailRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("RoomId");

                    b.ToTable("ReservationDetailRooms");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Guest", b =>
                {
                    b.HasOne("HotelApp.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("Guests")
                        .HasForeignKey("IdDocumentType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("HotelApp.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Reservations")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.ReservationDetailGuest", b =>
                {
                    b.HasOne("HotelApp.Domain.Entities.Guest", "Guest")
                        .WithMany("ReservationDetailGuests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HotelApp.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Guests")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.ReservationDetailRoom", b =>
                {
                    b.HasOne("HotelApp.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Rooms")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HotelApp.Domain.Entities.Room", "Room")
                        .WithMany("ReservationDetailRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Room", b =>
                {
                    b.HasOne("HotelApp.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HotelApp.Domain.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Guest", b =>
                {
                    b.Navigation("ReservationDetailGuests");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Reservation", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.Room", b =>
                {
                    b.Navigation("ReservationDetailRooms");
                });

            modelBuilder.Entity("HotelApp.Domain.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
