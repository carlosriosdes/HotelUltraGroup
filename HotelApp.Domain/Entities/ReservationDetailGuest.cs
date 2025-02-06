namespace HotelApp.Domain.Entities
{
    public class ReservationDetailGuest
    {
        public int Id { get; private set; }
        public int ReservationId { get; private set; }
        public int GuestId { get; private set; }

        // Propiedades de navegación (relaciones)
        public Reservation Reservation { get; private set; }
        public Guest Guest { get; private set; }

        // Constructor privado para garantizar que la creación de instancias solo se realice desde el dominio
        private ReservationDetailGuest() { }

        // Constructor público solo para crear instancias a través de los agregados y servicios
        public ReservationDetailGuest(Reservation reservation, Guest guest)
        {
            if (reservation == null)
                throw new ArgumentException("La reserva no puede estar vacia.", nameof(reservation));

            if (guest == null)
                throw new ArgumentException("El Uesped no puede ser vacio.", nameof(guest));

            Reservation = reservation;
            ReservationId = reservation.Id;
            Guest = guest;
            GuestId = guest.Id;
        }

        // Método estático para crear la relación entre Reservation y Guest (esto ayuda a mantener el constructor limpio)
        public static ReservationDetailGuest Create(Reservation reservation, Guest guest)
        {
            return new ReservationDetailGuest(reservation, guest);
        }
    }
}
