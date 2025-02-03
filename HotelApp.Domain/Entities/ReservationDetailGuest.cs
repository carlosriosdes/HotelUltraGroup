namespace HotelApp.Domain.Entities
{
    public class ReservationDetailGuest
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public Reservation Reservation { get; set; }
        public Guest Guest { get; set; }
    }
}
