using HotelApp.API.DTOs.Room;

namespace HotelApp.API.DTOs.Reservation
{
    public class GetReservationDetailDTO
    {
        public string HotelName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public List<GetRoomDTO> Rooms { get; set; }
        public List<GetGuestDTO> Guests { get; set; }
    }
}
