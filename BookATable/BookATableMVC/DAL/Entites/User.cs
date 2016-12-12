using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entites
{
    public class User:BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsVerify { get; set; }
        public virtual List<Role> Roles { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

    }
}
