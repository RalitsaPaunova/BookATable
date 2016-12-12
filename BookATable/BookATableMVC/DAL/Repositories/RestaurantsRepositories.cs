using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RestaurantsRepositories : BaseRepository<Restaurant>
    {
        public RestaurantsRepositories() : base()
        {

        }

        public RestaurantsRepositories(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
