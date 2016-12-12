using BookATableMVC.Helper;
using BookATableMVC.Tools;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookATableMVC.ViewModels.Reservations
{
    public class ReservationFilterViewModel:BaseFilterViewModel<Reservation>
    {       
        [FilterProperty(DisplayName = "People Count")]
        public int PeopleCount { get; set; }
        [FilterProperty(DisplayName = "Comment")]
        public string Comment { get; set; }
        [FilterProperty(DisplayName = "Reservation Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ReservationTime { get; set; }
        public override Expression<Func<Reservation, bool>> BuildFilter()
        {
            return (a => (a.UserId == AthenticationService.LoggedUser.Id) &&
                 ((a.Comment.Contains(this.Comment) || String.IsNullOrEmpty(this.Comment))) &&
                 (a.PeopleCount == this.PeopleCount || this.PeopleCount == default(int)) &&
                 (a.ReservationTime.Value == this.ReservationTime.Value || this.ReservationTime == null));
        }
    }
}