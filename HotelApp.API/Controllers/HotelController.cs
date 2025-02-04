using HotelApp.API.DTOs.Hotel;
using HotelApp.API.Mappers;
using HotelApp.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelDTO>>> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelService.GetAllHotelsAsync();

                if (hotels == null || !hotels.Any())
                {
                    return NoContent();
                }

                var hotelDtos = hotels.Select(HotelMapper.HotelToDTO);
                return Ok(hotelDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al consultar los hoteles.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelDTO>> GetHotelById(int id)
        {
            try
            {
                var hotelEntity = await _hotelService.GetHotelByIdAsync(id);

                if (hotelEntity == null)
                {
                    return NotFound(new { message = "No se encontro el hotel." });
                }

                var hotelDto = HotelMapper.HotelToDTO(hotelEntity);
                return Ok(hotelDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Se produjo un error al consultar los hoteles.", error = ex.Message });
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddHotel(AddHotelDTO hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newHotel = HotelMapper.ResponseHotelToDTO(await _hotelService.AddHotelAsync(HotelMapper.AddHotelDTOtoModel(hotel)));

                return CreatedAtAction(nameof(GetHotelById), new { id = newHotel.Id }, newHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al agregar el hotel.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, UpdateHotelDTO hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedHotel = HotelMapper.UpdateHotelDTOtoModel(hotel);
                updatedHotel.Id = id;

                var result = await _hotelService.UpdateHotelAsync(updatedHotel);

                if (result == null)
                {
                    return NotFound(new { message = "No se encontro el hotel." });
                }

                var updateHotelDto = HotelMapper.ResponseUpdateHotelToDTO(result);
                return Ok(new { message = "Se actualizo el hotel correctamente.", updateHotelDto });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al actualizar el hotel.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            return Ok();
        }


        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateHotelStatus(int id, [FromBody] UpdateHotelStatusDTO updateStatusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _hotelService.GetHotelByIdAsync(id);

                if (hotel == null)
                {
                    return NotFound(new { message = "No se encontró el hotel." });
                }

                await _hotelService.UpdateHotelStatusAsync(updateStatusDto.IsActive, hotel);

                return Ok(new { message = "Estado del hotel actualizado correctamente.", isActive = hotel.IsActive });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al actualizar el estado del hotel.", error = ex.Message });
            }
        }
    }
}
