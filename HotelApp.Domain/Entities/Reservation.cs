using HotelApp.Domain.Common;
using HotelApp.Domain.Events;

namespace HotelApp.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; private set; }
        public int HotelId { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string EmergencyContactName { get; private set; }
        public string EmergencyContactPhone { get; private set; }

        public Hotel Hotel { get; private set; }

        private readonly List<ReservationDetailRoom> _rooms = [];
        private readonly List<ReservationDetailGuest> _guests = [];

        public IReadOnlyCollection<ReservationDetailRoom> Rooms => _rooms.AsReadOnly();
        public IReadOnlyCollection<ReservationDetailGuest> Guests => _guests.AsReadOnly();

        private Reservation() { }

        public Reservation(int hotelId, DateTime checkInDate, DateTime checkOutDate, decimal totalPrice, string emergencyContactName, string emergencyContactPhone)
        {
            HotelId = hotelId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalPrice = totalPrice;
            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;
        }

        public static Reservation Create(int hotelId, DateTime checkInDate, DateTime checkOutDate, decimal totalPrice, string emergencyContactName, string emergencyContactPhone)
        {
            return new Reservation(hotelId, checkInDate, checkOutDate, totalPrice, emergencyContactName, emergencyContactPhone);
        }
        public void Confirm(string email, string customerName)
        {
            var domainEvent = new ReservationConfirmedEvent(Id, email, customerName);
            DomainEvents.Raise(domainEvent);
        }

        public void AddRoom(int roomId)
        {
            _rooms.Add(new ReservationDetailRoom(this, roomId));
        }

        public void AddGuest(Guest guest)
        {
            _guests.Add(new ReservationDetailGuest(this, guest));
        }
    }
}
