using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository() : base()
        {

        }

        public UsersRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
