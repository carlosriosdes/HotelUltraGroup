using HotelApp.API.DTOs.Hotel;
using HotelApp.Domain.Entities;

namespace HotelApp.API.Mappers
{
    public static class HotelMapper
    {
        public static Hotel AddHotelDTOtoModel(AddHotelDTO addHotelDTO)
        {
            return new Hotel
            {
                Name = addHotelDTO.Name,
                Address = addHotelDTO.Address,
                City = addHotelDTO.City,
                IsActive = true
            };
        }

        public static Hotel UpdateHotelDTOtoModel(UpdateHotelDTO updateHotelDTO)
        {
            return new Hotel
            {
                Name = updateHotelDTO.Name,
                Address = updateHotelDTO.Address,
                City = updateHotelDTO.City,
                IsActive = updateHotelDTO.IsActive
            };
        }

        public static GetHotelDTO HotelToDTO(Hotel hotel)
        {
            return new GetHotelDTO
            {
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                IsActive = hotel.IsActive ? "Activo" : "Inactivo"
            };
        }

        public static ResponseAddHotelDTO ResponseHotelToDTO(Hotel hotel)
        {
            return new ResponseAddHotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                IsActive = hotel.IsActive ? "Activo" : "Inactivo"
            };
        }

        public static ResponseUpdateHotelDTO ResponseUpdateHotelToDTO(Hotel hotel)
        {
            return new ResponseUpdateHotelDTO
            {
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                IsActive = hotel.IsActive ? "Activo" : "Inactivo"
            };
        }
    }
}
