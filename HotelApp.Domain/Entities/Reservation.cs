namespace HotelApp.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public Hotel Hotel { get; set; }
    }
}
