using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels.Reservations
{
    public class ReservationListViewModel:BaseAllViewModel<Reservation,ReservationFilterViewModel>
    {
        //public List<Reservation> Reservations { get; set; }
       // public PagerViewModel Pager { get; set; }
    }
}