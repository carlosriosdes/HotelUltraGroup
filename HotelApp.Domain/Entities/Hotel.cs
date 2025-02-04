namespace HotelApp.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Room> Rooms { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
        public void Enable() => IsActive = true;
        public void Disable() => IsActive = false;
    }
}
