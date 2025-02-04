using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.DTOs.Room
{
    public class UpdateRoomDTO
    {
        [Required(ErrorMessage = "La locasion del room es obligatorio.")]
        [StringLength(100, ErrorMessage = "La locasion no puede exceder los 100 caracteres.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "El precio base del room es obligatorio.")]
        public decimal BasePrice { get; set; }
        [Required(ErrorMessage = "El impuesto del room es obligatorio.")]
        public decimal Tax { get; set; }
        public bool IsActive { get; set; }
    }
}
