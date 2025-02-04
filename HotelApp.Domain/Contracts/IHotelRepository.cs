using HotelApp.Domain.Entities;

namespace HotelApp.Domain.Contracts
{
    public interface IHotelRepository
    {
        Task<Hotel> AddAsync(Hotel hotel);
        Task<Hotel> GetByIdAsync(int id);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> UpdateAsync(Hotel hotel);
        Task DeleteAsync(int id);
    }
}
