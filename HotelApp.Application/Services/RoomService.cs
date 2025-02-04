using HotelApp.Application.Contracts;
using HotelApp.Application.Utilities;
using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;
using System.Net;

namespace HotelApp.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;

        public RoomService(IRoomRepository roomRepository, IHotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            var newRoom = await _roomRepository.AddAsync(room);
            return newRoom;
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            var updateRoom = await _roomRepository.UpdateAsync(room);
            return updateRoom;
        }

        public async Task UpdateRoomStatusAsync(bool isActive, Room room)
        {
            if (isActive)
            {
                room.Enable();
            }
            else
            {
                room.Disable();
            }
            await _roomRepository.UpdateAsync(room);
        }

        public async Task AssignRoomsToHotelAsync(int hotelId, List<int> roomIds)
        {
            var rooms = await _roomRepository.GetRoomsByIdsAsync(roomIds);

            foreach (var room in rooms)
            {
                room.HotelId = hotelId;
            }

            await _roomRepository.UpdateRoomsAsync(rooms);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteAsync(id);
        }
    }
}
