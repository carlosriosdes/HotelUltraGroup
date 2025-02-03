namespace HotelApp.Domain.Entities
{
    public class ReservationDetailRoom
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public Reservation Reservation { get; set; }
        public Room Room { get; set; }
    }
}
