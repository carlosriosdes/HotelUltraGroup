using HotelApp.Application.Contracts;
using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;

namespace HotelApp.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository) 
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public async Task<Hotel> AddHotelAsync(Hotel hotel)
        {
            var responseHotel = await _hotelRepository.AddAsync(hotel);
            return responseHotel;
        }

        public async Task<Hotel> UpdateHotelAsync(Hotel hotel)
        {
            var responseHotel = await _hotelRepository.UpdateAsync(hotel);
            return responseHotel;
        }

        public async Task UpdateHotelStatusAsync(bool isActive, Hotel hotel)
        {
            if (isActive)
            {
                hotel.Enable();
            }
            else
            {
                hotel.Disable();
            }
            await _hotelRepository.UpdateAsync(hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _hotelRepository.DeleteAsync(id);
        }
    }
}
