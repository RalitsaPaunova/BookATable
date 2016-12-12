using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels.Restaurants
{
    public class RestaurantListViewModel:BaseAllViewModel<Restaurant,RestaurantFilterViewModel>
    {
       // public List<Restaurant> Restaurants { get; set; }
       // public PagerViewModel  Pager { get; set; }
    }
}