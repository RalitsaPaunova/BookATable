using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReservationsRepository : BaseRepository<Reservation>
    {
        public ReservationsRepository() : base()
        {

        }

        public ReservationsRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }


}
