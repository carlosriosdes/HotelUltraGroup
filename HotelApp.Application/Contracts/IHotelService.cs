using HotelApp.Domain.Entities;

namespace HotelApp.Application.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> AddHotelAsync(Hotel hotel);
        Task<Hotel> UpdateHotelAsync(Hotel hotel);
        Task UpdateHotelStatusAsync(bool isActive, Hotel hotel);
        Task DeleteHotelAsync(int id);
    }
}
