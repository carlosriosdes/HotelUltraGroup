using HotelApp.Application.Contracts;
using HotelApp.Domain.Contracts;
using HotelApp.Domain.Entities;
using HotelApp.Domain.Events;
using MediatR;

namespace HotelApp.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMediator _mediator;

        public ReservationService(IReservationRepository reservationRepository, IMediator mediator)
        {
            _reservationRepository = reservationRepository;
            _mediator = mediator;
        }

        public async Task<int> CreateReservationAsync(Reservation reservation, List<int> idRooms, List<Guest> listGuest)
        {
            foreach (int idRoom in idRooms)
            {
                reservation.AddRoom(idRoom);
            }

            foreach (Guest guest in listGuest)
            {
                reservation.AddGuest(guest);
            }

            await _reservationRepository.AddAsync(reservation);

            foreach (Guest guest in listGuest)
            {
                reservation.Confirm(guest.Email, guest.FullName);

                await _mediator.Publish(new ReservationConfirmedEvent(reservation.Id, guest.Email, guest.FullName));
            }
            

            return reservation.Id;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllDetailsAsync()
        {
            return await _reservationRepository.GetAllDetailsAsync();
        }
    }
}
