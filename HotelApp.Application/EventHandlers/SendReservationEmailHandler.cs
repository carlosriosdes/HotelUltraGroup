using HotelApp.Domain.Contracts;
using HotelApp.Domain.Events;
using MediatR;

namespace HotelApp.Application.EventHandlers
{
    public class SendReservationEmailHandler : INotificationHandler<ReservationConfirmedEvent>
    {
        private readonly IEmailService _emailService;

        public SendReservationEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(ReservationConfirmedEvent notification, CancellationToken cancellationToken)
        {
            var subject = "Confirmación de Reserva";
            var body = $"Hola {notification.CustomerName}, tu reserva {notification.ReservationId} ha sido confirmada.";
            await _emailService.SendEmailAsync(notification.Email, subject, body);
        }
    }
}
