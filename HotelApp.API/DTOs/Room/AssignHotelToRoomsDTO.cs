using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.DTOs.Room
{
    public class AssignHotelToRoomsDTO
    {
        [Required(ErrorMessage = "El Id del hotel es obligatorio.")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Es obligatorio al menos una habitacion.")]
        public List<int> ListRoomsId { get; set; }
    }
}
