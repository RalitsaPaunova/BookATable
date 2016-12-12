using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entites
{
    public class Restaurant:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required] 
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public int Capacity { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OpenHour { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CloseHour { get; set; }

        public string ImagePath { get; set; }
        public int? ManagerId { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        
    }
}
