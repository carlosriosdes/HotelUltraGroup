namespace HotelApp.API.DTOs.Reservation
{
    public class AddReservationDTO
    {
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public List<int> RoomsID { get; set; }
        public List<GuestDTO> Guests { get; set; }  

    }

    public class GuestDTO
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class GetGuestDTO
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}