using BookATableMVC.Services.EntityServices;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.Helper.EntityServices
{
    public class RestaurantService:BaseService<Restaurant>
    {
        public RestaurantService():base()
        {

        }
        public RestaurantService(UnitOfWork unitOfWork) :base(unitOfWork)
        {

        }
    }
}