using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;
using HotelApp.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Infraestructure.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelUltraGroupContext _context;

        public HotelRepository(HotelUltraGroupContext context)
        {
            _context = context;
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.Include(h => h.Rooms).ToListAsync();
        }

        public async Task<Hotel> UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
