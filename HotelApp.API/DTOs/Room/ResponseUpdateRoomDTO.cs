namespace HotelApp.API.DTOs.Room
{
    public class ResponseUpdateRoomDTO
    {
        public string RoomType { get; set; }
        public string Location { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public string IsActive { get; set; }
    }
}
