using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;
using HotelApp.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Infraestructure.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelUltraGroupContext _context;

        public RoomRepository(HotelUltraGroupContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.Include(r => r.RoomType).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.Include(r => r.RoomType).Include(x => x.Hotel).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Room> AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();

            await _context.Entry(room)
                  .Reference(r => r.RoomType)
                  .LoadAsync();

            return room;
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();

            await _context.Entry(room)
                  .Reference(r => r.RoomType)
                  .LoadAsync();

            return room;
        }
        public async Task UpdateRoomsAsync(ICollection<Room> rooms)
        {
            _context.Rooms.UpdateRange(rooms);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Room>> GetRoomsByIdsAsync(List<int> roomIds)
        {
            return await _context.Rooms.Where(r => roomIds.Contains(r.Id)).ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}