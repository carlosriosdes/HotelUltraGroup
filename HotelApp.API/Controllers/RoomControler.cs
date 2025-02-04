using HotelApp.API.DTOs.Hotel;
using HotelApp.API.DTOs.Room;
using HotelApp.API.Mappers;
using HotelApp.Application.Contracts;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomControler : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IHotelService _hotelService;
        public RoomControler(IRoomService roomService, IHotelService hotelService)
        {
            _roomService = roomService;
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<ActionResult> AddRoom(AddRoomDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newRoom = RoomMapper.ResponseRoomToDTO(await _roomService.AddRoomAsync(RoomMapper.AddRoomDTOtoModel(roomDto)));

                return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.Id }, newRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al agregar el hotel.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRoomDTO>> GetRoomById(int id)
        {
            try
            {
                var roomEntity = await _roomService.GetRoomByIdAsync(id);

                if (roomEntity == null)
                {
                    return NotFound();
                }

                var roomDto = RoomMapper.RoomToDTO(roomEntity);
                return Ok(roomDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al consultar las habitaciones.", error = ex.Message });
            }
        }

        [HttpPatch("assign-hotel")]
        public async Task<ActionResult> AssignRoomsToHotel(AssignHotelToRoomsDTO assignHotelToRoomsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _hotelService.GetHotelByIdAsync(assignHotelToRoomsDTO.HotelId);

                if (hotel == null)
                {
                    return NotFound(new { message = "No se encontró el hotel." });
                }

                await _roomService.AssignRoomsToHotelAsync(assignHotelToRoomsDTO.HotelId, assignHotelToRoomsDTO.ListRoomsId);

                return Ok(new { message = "Se actualizaron las habitaciones de forma correcta.", isActive = hotel.IsActive });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al actualizar las habitaciones.", error = ex.Message });
            } 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, UpdateRoomDTO room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var roomEntity = await _roomService.GetRoomByIdAsync(id);

                if (roomEntity == null)
                {
                    return NotFound();
                }

                var updatedRoom = RoomMapper.UpdateRoomDTOtoModel(room, roomEntity);
                var result = await _roomService.UpdateRoomAsync(updatedRoom);
                var updateHotelDto = RoomMapper.ResponseUpdateRoomToDTO(result);
                return Ok(new { message = "Se actualizo el room correctamente.", updateHotelDto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al actualizar el room.", error = ex.Message });
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateRoomStatus(int id, [FromBody] UpdateRoomStatusDTO updateStatusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var room = await _roomService.GetRoomByIdAsync(id);

                if (room == null)
                {
                    return NotFound(new { message = "No se encontró el room." });
                }

                await _roomService.UpdateRoomStatusAsync(updateStatusDto.IsActive, room);

                return Ok(new { message = "Estado del room actualizado correctamente.", isActive = room.IsActive });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al actualizar el estado del room.", error = ex.Message });
            }
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<GetRoomDTO>>> GetAllRooms()
        //{
        //    try
        //    {
        //        var rooms = await _roomService.GetAllRoomsAsync();

        //        if (rooms == null || !rooms.Any())
        //        {
        //            return NoContent();
        //        }

        //        var roomDtos = rooms.Select(RoomMapper.RoomToDTO);
        //        return Ok(roomDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Se produjo un error al consultar las habitaciones.", error = ex.Message });
        //    }
        //}





    }
}
