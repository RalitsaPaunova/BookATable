using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthActionRepository:BaseRepository<AuthAction>
    {
        public AuthActionRepository()
            : base()
        {

        }

        public AuthActionRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
