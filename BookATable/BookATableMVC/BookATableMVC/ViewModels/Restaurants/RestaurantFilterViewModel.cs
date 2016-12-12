using BookATableMVC.Helper;
using BookATableMVC.Tools;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookATableMVC.ViewModels.Restaurants
{
    public class RestaurantFilterViewModel:BaseFilterViewModel<Restaurant>
    {
        [FilterProperty(DisplayName = "Name")]
        public string Name { get; set; }
        [FilterProperty(DisplayName = "Address")]
        public string Address { get; set; }
        [FilterProperty(DisplayName = "Email")]
        public string Email { get; set; }
        [FilterProperty(DisplayName = "Capacity")]
        public int Capacity { get; set; }
        [FilterProperty(DisplayName = "Open Hour")]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OpenHour { get; set; }
        [FilterProperty(DisplayName = "Close Hour")]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CloseHour { get; set; }


        public override Expression<Func<Restaurant, bool>> BuildFilter()
        {
            return (a =>(a.ManagerId == AthenticationService.LoggedUser.Id ) &&
                  ((a.Name.Contains(this.Name) || String.IsNullOrEmpty(this.Name))) &&
                  ((a.Address.Contains(this.Address) || String.IsNullOrEmpty(this.Address))) &&
                  ((a.Email.Contains(this.Email) || String.IsNullOrEmpty(this.Email))) &&
                  (a.Capacity == this.Capacity || this.Capacity == default(int)) &&
                  (a.OpenHour.Value.Hour == this.OpenHour.Value.Hour || this.OpenHour == null) &&
                  (a.CloseHour.Value.Hour == this.CloseHour.Value.Hour || this.CloseHour == null));
        }
    }
}