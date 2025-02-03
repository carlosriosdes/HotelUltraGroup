using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guest> Guests { get; set; }
    }
}
