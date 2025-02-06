using HotelApp.API.DTOs.Hotel;
using HotelApp.API.DTOs.Reservation;
using HotelApp.API.DTOs.Room;
using HotelApp.Domain.Entities;

namespace HotelApp.API.Mappers
{
    public static class ReservationMapper
    {
        public static Reservation AddReservationDTOtoModel(AddReservationDTO addReservationDTO)
        {
            return Reservation.Create
            (
                hotelId: addReservationDTO.HotelId,
                checkInDate: addReservationDTO.CheckInDate,
                checkOutDate: addReservationDTO.CheckInDate,
                totalPrice: addReservationDTO.TotalPrice,
                emergencyContactName: addReservationDTO.EmergencyContactName,
                emergencyContactPhone: addReservationDTO.EmergencyContactPhone
            );
        }

        public static Guest AddGuestDTOtoModel(GuestDTO addGuestDTO)
        {
            return new Guest
            {
                FullName = addGuestDTO.FullName,
                BirthDate = addGuestDTO.BirthDate,
                Gender = addGuestDTO.Gender,
                IdDocumentType = addGuestDTO.IdDocumentType,
                DocumentNumber = addGuestDTO.DocumentNumber,
                Email = addGuestDTO.Email,
                PhoneNumber = addGuestDTO.PhoneNumber
            };
        }

        public static GetReservationDTO ModelToGetReservationDTO(Reservation getAllReservationDTO)
        {
            return new GetReservationDTO
            {
                HotelName = getAllReservationDTO.Hotel.Name,
                CheckInDate = getAllReservationDTO.CheckInDate,
                CheckOutDate = getAllReservationDTO.CheckOutDate,
                TotalPrice = getAllReservationDTO.TotalPrice,
                EmergencyContactName = getAllReservationDTO.EmergencyContactName,
                EmergencyContactPhone = getAllReservationDTO.EmergencyContactPhone
            };
        }

        public static GetReservationDetailDTO ModelToGetReservationDetailDTO(Reservation getAllReservationDTO)
        {
            var rooms = getAllReservationDTO.Rooms.Select(room => new GetRoomDTO
            {
                Location = room.Room.Location,
                BasePrice = room.Room.BasePrice.ToString(),
                Tax = room.Room.Tax.ToString(),
                IsActive = room.Room.IsActive ? "Activo" : "Inactivo",
                Hotel = room.Reservation.Hotel.Name,
                RoomType = room.Room.RoomType.Name
            }).ToList();

            var guests = getAllReservationDTO.Guests.Select(guest => new GetGuestDTO
            {
                FullName = guest.Guest.FullName,
                BirthDate = guest.Guest.BirthDate,
                Gender = guest.Guest.Gender,
                IdDocumentType = guest.Guest.DocumentType.Name,
                DocumentNumber = guest.Guest.DocumentNumber,
                Email = guest.Guest.Email,
                PhoneNumber = guest.Guest.PhoneNumber
            }).ToList();

            return new GetReservationDetailDTO
            {
                HotelName = getAllReservationDTO.Hotel.Name,
                CheckInDate = getAllReservationDTO.CheckInDate,
                CheckOutDate = getAllReservationDTO.CheckOutDate,
                TotalPrice = getAllReservationDTO.TotalPrice,
                EmergencyContactName = getAllReservationDTO.EmergencyContactName,
                EmergencyContactPhone = getAllReservationDTO.EmergencyContactPhone,
                Rooms = rooms,
                Guests = guests
            };
        }
    }
}
