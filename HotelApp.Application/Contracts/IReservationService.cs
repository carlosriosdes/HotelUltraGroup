using HotelApp.Domain.Entities;

namespace HotelApp.Application.Contracts
{
    public interface IReservationService
    {
        Task<int> CreateReservationAsync(Reservation reservation, List<int> idRooms, List<Guest> listGuest);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetAllDetailsAsync();
    }
}
