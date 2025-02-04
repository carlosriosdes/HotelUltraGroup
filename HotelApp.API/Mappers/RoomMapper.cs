using HotelApp.API.DTOs.Hotel;
using HotelApp.API.DTOs.Room;
using HotelApp.Domain.Entities;

namespace HotelApp.API.Mappers
{
    public static class RoomMapper
    {
        public static Room AddRoomDTOtoModel(AddRoomDTO addRoomDTO)
        {
            return new Room
            {
                RoomTypeId = addRoomDTO.RoomTypeId,
                Location = addRoomDTO.Location,
                BasePrice = addRoomDTO.BasePrice,
                Tax = addRoomDTO.Tax,
                IsActive = true
            };
        }
        public static GetRoomDTO RoomToDTO(Room room)
        {
            return new GetRoomDTO
            {
                Hotel = room.Hotel != null ? room.Hotel.Name : "Sin Hotel",
                RoomType = room.RoomType.Name,
                Location = room.Location,
                BasePrice = room.BasePrice.ToString(),
                Tax = room.Tax.ToString(),
                IsActive = room.IsActive ? "Activo" : "Inactivo"
            };
        }

        public static Room UpdateRoomDTOtoModel(UpdateRoomDTO updateRoomDTO, Room roomEntity)
        {
            roomEntity.Location = updateRoomDTO.Location;
            roomEntity.BasePrice = updateRoomDTO.BasePrice;
            roomEntity.Tax = updateRoomDTO.Tax;
            roomEntity.IsActive = updateRoomDTO.IsActive;
            return roomEntity;
        }       

        public static ResponseAddRoomDTO ResponseRoomToDTO(Room room)
        {
            return new ResponseAddRoomDTO
            {
                Id = room.Id,
                BasePrice = room.BasePrice,
                Location = room.Location,
                Tax = room.Tax,
                IsActive = room.IsActive ? "Activo" : "Inactivo",
                RoomType = room.RoomType.Name
            };
        }

        public static ResponseUpdateRoomDTO ResponseUpdateRoomToDTO(Room room)
        {
            return new ResponseUpdateRoomDTO
            {
                BasePrice = room.BasePrice,
                Location = room.Location,
                Tax = room.Tax,
                IsActive = room.IsActive ? "Activo" : "Inactivo",
                RoomType = room.RoomType.Name
            };
        }
    }
}
