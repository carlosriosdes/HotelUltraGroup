using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.DTOs.Hotel
{
    public class UpdateHotelStatusDTO
    {
        [Required(ErrorMessage = "El estado del hotel es obligatorio.")]
        public bool IsActive { get; set; }
    }
}
