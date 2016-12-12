using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{

    public class AuthAction:BaseEntity
    {
        public string Name { get; set; }
        public int ControllerId { get; set; }
        public Method MethodType{ get; set; }
        public enum Method
        {
            GET,
            POST
        }
        [ForeignKey("ControllerId")]
        public virtual AuthController AuthController { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
