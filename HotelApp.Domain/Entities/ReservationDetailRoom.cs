namespace HotelApp.Domain.Entities
{
    public class ReservationDetailRoom
    {
        public int Id { get; private set; }
        public int ReservationId { get; private set; }
        public int RoomId { get; private set; }

        public Reservation Reservation { get; private set; }
        public Room Room { get; private set; }

        private ReservationDetailRoom() { }

        public ReservationDetailRoom(Reservation reservation, int roomId)
        {
            if (reservation == null)
                throw new ArgumentException("La reserva no puede estar vacia.", nameof(reservation));

            if (roomId <= 0)
                throw new ArgumentException("El ID de la habitación debe ser mayor que cero.", nameof(roomId));

            Reservation = reservation;
            ReservationId = reservation.Id;
            RoomId = roomId;
        }
        public static ReservationDetailRoom Create(Reservation reservation, int roomId)
        {
            return new ReservationDetailRoom(reservation, roomId);
        }
    }

}
