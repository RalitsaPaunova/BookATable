using BookATableMVC.Helper.EntityServices;
using BookATableMVC.Services.EntityServices;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Service.EntityServices
{
    public class ReservationService : BaseService<Reservation>
    {
        public ReservationService() : base()
        {

        }

        public ReservationService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool CheckFreeSeats(Reservation reservation)
        {
          
            RestaurantService restService = new RestaurantService();
            Restaurant restaurant = restService.GetById(reservation.RestaurantId);
            ReservationService service = new ReservationService();
          
            int totalPeople = service.GetAll(r => r.RestaurantId == reservation.RestaurantId 
                                                          && r.ReservationTime == reservation.ReservationTime)

                                                         .Select(r => r.PeopleCount).ToList().Sum();
            if (reservation.PeopleCount < (restaurant.Capacity - totalPeople))
            {
                return true;
            }

            return false;

        }
    }
}
