namespace HotelApp.Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int IdDocumentType { get; set; } 
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public ICollection<ReservationDetailGuest> ReservationDetailGuests { get; set; } = [];
    }
}
