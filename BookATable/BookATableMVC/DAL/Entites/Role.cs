using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<AuthAction> AuthActions { get; set; }
    }
}
