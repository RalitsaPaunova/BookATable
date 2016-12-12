using BookATableMVC.Filters;
using BookATableMVC.Helper.EntityServices;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.ViewModels.Reservations
{
    public class ReservationAddEditViewModel:BaseByIdViewModel
    {

        public ReservationAddEditViewModel()
        {
            this.Restaurants = GetRestaurants();
        }
       
        [Required]
        [DateValidator]
        public DateTime? ReservationTime { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int PeopleCount { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
       
        public List<SelectListItem> Restaurants { get ; private set; }
        private List<SelectListItem> GetRestaurants()
        {
            RestaurantService service = new RestaurantService();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in service.GetAll().ToList())
            {
                items.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            return items;
        }

    }
}