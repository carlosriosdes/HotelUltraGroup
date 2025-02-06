using HotelApp.Domain.Common;
using MediatR;

namespace HotelApp.Domain.Events
{
    public class ReservationConfirmedEvent : IDomainEvent, INotification
    {
        public int ReservationId { get; }
        public string Email { get; }
        public string CustomerName { get; }

        public ReservationConfirmedEvent(int reservationId, string email, string customerName)
        {
            ReservationId = reservationId;
            Email = email;
            CustomerName = customerName;
        }
    }
}
