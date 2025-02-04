using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.DTOs.Hotel
{
    public class AddHotelDTO
    {
        [Required(ErrorMessage = "El nombre del hotel es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La dirección del hotel es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(100, ErrorMessage = "El nombre de la ciudad no puede exceder los 100 caracteres.")]
        public string City { get; set; }
    }
}
