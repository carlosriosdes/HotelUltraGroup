using HotelApp.Domain.Entities;

namespace HotelApp.Domain.Contracts
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task<Room> AddAsync(Room room);
        Task<Room> UpdateAsync(Room room);
        Task UpdateRoomsAsync(ICollection<Room> rooms);
        Task<ICollection<Room>> GetRoomsByIdsAsync(List<int> roomIds);
        Task DeleteAsync(int id);
    }
}
