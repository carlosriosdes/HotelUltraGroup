using HotelApp.Domain.Entities;
using HotelApp.Infraestructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Infraestructure.Persistence.Context
{
    public class HotelUltraGroupContext : DbContext
    {
        public HotelUltraGroupContext(DbContextOptions<HotelUltraGroupContext> options) : base(options){}

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationDetailGuest> ReservationDetailGuests { get; set; }
        public DbSet<ReservationDetailRoom> ReservationDetailRooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationDetailRoomConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationDetailGuestConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
        }
    }
}
