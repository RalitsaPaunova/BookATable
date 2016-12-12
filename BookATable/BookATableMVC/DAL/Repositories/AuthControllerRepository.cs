using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthControllerRepository:BaseRepository<AuthController>
    {
        public AuthControllerRepository()
            : base()
        {

        }

        public AuthControllerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
