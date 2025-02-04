using HotelApp.Application.Utilities;
using HotelApp.Domain.Entities;

namespace HotelApp.Application.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task UpdateRoomStatusAsync(bool isActive, Room room);
        Task AssignRoomsToHotelAsync(int hotelId, List<int> roomIds); 
        Task DeleteRoomAsync(int id);
    }
}
