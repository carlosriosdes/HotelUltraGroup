using HotelApp.API.DTOs.Room;

namespace HotelApp.API.DTOs.Hotel
{
    public class GetHotelDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string IsActive { get; set; }
    }
}
