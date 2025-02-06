using HotelApp.Domain.Entities;

namespace HotelApp.Domain.Contracts
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(int id);
        Task AddAsync(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetAllDetailsAsync();
    }
}
