using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;
using HotelApp.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Infraestructure.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelUltraGroupContext _context;

        public ReservationRepository(HotelUltraGroupContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Rooms)
                .Include(r => r.Guests)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.Include(h => h.Hotel).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllDetailsAsync()
        {
            return await _context.Reservations
                            .Include(h => h.Hotel)  
                            .Include(r => r.Rooms)  
                                .ThenInclude(room => room.Room)
                                    .ThenInclude(room => room.RoomType)
                            .Include(g => g.Guests) 
                                .ThenInclude(guest => guest.Guest) 
                                    .ThenInclude(guest => guest.DocumentType)
                            .ToListAsync();
        }


        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
