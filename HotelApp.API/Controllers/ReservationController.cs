using HotelApp.API.DTOs.Reservation;
using HotelApp.API.Mappers;
using HotelApp.Application.Contracts;
using HotelApp.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _ReservationService;

        public ReservationController(IReservationService reservationService) {
            _ReservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult> AddReservation(AddReservationDTO objReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var reservation = ReservationMapper.AddReservationDTOtoModel(objReservation);
                var listGuest = objReservation.Guests.Select(ReservationMapper.AddGuestDTOtoModel).ToList();
                var newReservation = await _ReservationService.CreateReservationAsync(reservation, objReservation.RoomsID, listGuest);
                return Ok(new { message = ResponseMessages.Success, reservationId = newReservation });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ResponseMessages.InternalServerError, error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _ReservationService.GetAllAsync();
                var reservationsDTO = reservations.Select(ReservationMapper.ModelToGetReservationDTO);
                return Ok(new { message = ResponseMessages.Success, reservationsDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ResponseMessages.InternalServerError, error = ex.Message });
            }
        }

        [HttpGet("details")]
        public async Task<ActionResult> GetAllReservationsDetails()
        {
            try
            {
                var reservations = await _ReservationService.GetAllDetailsAsync();
                var reservationsDTO = reservations.Select(ReservationMapper.ModelToGetReservationDetailDTO);
                return Ok(reservationsDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ResponseMessages.InternalServerError, error = ex.Message });
            }
        }
    }
}
