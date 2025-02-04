using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.DTOs.Room
{
    public class UpdateRoomStatusDTO
    {
        [Required(ErrorMessage = "El estado del room es obligatorio.")]
        public bool IsActive { get; set; }
    }
}
