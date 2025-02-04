namespace HotelApp.API.DTOs.Room
{
    public class GetRoomDTO
    {
        public string Hotel { get; set; }
        public string RoomType { get; set; }
        public string Location { get; set; }
        public string BasePrice { get; set; }
        public string Tax { get; set; }
        public string IsActive { get; set; }
    }
}
