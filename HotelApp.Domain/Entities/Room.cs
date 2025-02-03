namespace HotelApp.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int IdRoomType { get; set; }
        public string Location { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public bool IsActive { get; set; }
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
    }
}
