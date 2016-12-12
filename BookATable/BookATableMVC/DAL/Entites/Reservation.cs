using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entites
{
    public class Reservation:BaseEntity
    {
        [Required]
       public DateTime? ReservationTime { get; set; }
        [Required]
        public int PeopleCount { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        


        
    }
}
