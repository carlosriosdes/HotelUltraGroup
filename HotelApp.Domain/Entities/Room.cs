namespace HotelApp.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public string Location { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public bool IsActive { get; set; }
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<ReservationDetailRoom> ReservationDetailRooms { get; set; } = [];
        public void Enable() => IsActive = true;
        public void Disable() => IsActive = false;
        public void AssignHotel(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
