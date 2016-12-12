using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using DAL.Entites;
using BookATableMVC.ViewModels.Restaurants;
using System.IO;
using BookATableMVC.Helper.EntityServices;
using BookATableMVC.ViewModels;
using BookATableMVC.Filters;
using BookATableMVC.Services.EntityServices;

namespace BookATableMVC.Controllers
{
    //    [AuthorizationFilter]
    [AuthenticationFilter]
    public class RestaurantsController : BaseController<Restaurant,RestaurantFilterViewModel ,RestaurantListViewModel, RestaurantAddEditViewModel>
    {
        public ActionResult Details(int? id)
        {

            Restaurant restaurant = new Restaurant();
            RestaurantService service = new RestaurantService();
            restaurant = service.GetById(id.Value);

            return View(restaurant);

        }
        protected override BaseService<Restaurant> CreateService()
        {
            return new RestaurantService();
        }

        protected override void PopulateViewModel(RestaurantAddEditViewModel model, Restaurant restorant)
        {
            model.Id = restorant.Id;
            model.Name = restorant.Name;
            model.Address = restorant.Address;
            model.Phone = restorant.Phone;
            model.Email = restorant.Email;
            model.Capacity = restorant.Capacity;
            model.OpenHour = restorant.OpenHour;
            model.CloseHour = restorant.CloseHour;

        }

        protected override void PopulateEntity(Restaurant restorant, RestaurantAddEditViewModel model)
        {
            restorant.Id = model.Id;
            restorant.Name = model.Name;
            restorant.Address = model.Address;
            restorant.Phone = model.Phone;
            restorant.Email = model.Email;
            restorant.Capacity = model.Capacity;
            restorant.OpenHour = model.OpenHour;
            restorant.CloseHour = model.CloseHour;
            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                var imageExtension = Path.GetExtension(model.ImageUpload.FileName);

                if (String.IsNullOrEmpty(imageExtension) || !imageExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError(string.Empty, "Wrong image format.");
                }
                else
                {
                    string filePath = Server.MapPath("~/Uploads/");
                    model.ImagePath = model.ImageUpload.FileName;
                    model.ImageUpload.SaveAs(filePath + model.ImagePath);
                }
            }
            else
            {
                model.ImagePath = "default.jpg";
            }
            restorant.ImagePath = model.ImagePath;
        }
        //[AuthenticationFilter]
        //    //GET Action
        //    public ActionResult Edit(int? id)
        //    {
        //        Restaurant restaurant;
        //        if (!id.HasValue)
        //        {
        //            restaurant = new Restaurant();
        //        }
        //        else
        //        {
        //            RestaurantService service = new RestaurantService();
        //            restaurant = service.GetById(id.Value);
        //            if (restaurant == null)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        RestaurantAddEditViewModel model = new RestaurantAddEditViewModel();


        //        model.Id = restaurant.Id;
        //        model.Name = restaurant.Name;
        //        model.Address = restaurant.Address;
        //        model.Email = restaurant.Email;
        //        model.Phone = restaurant.Phone;
        //        model.Capacity = restaurant.Capacity;
        //        model.CloseHour = restaurant.CloseHour;
        //        model.OpenHour = restaurant.OpenHour;
        //        model.ImagePath = restaurant.ImagePath;
        //        return View(model);
        //    }

        //    [HttpPost]
        //    public ActionResult Edit(RestaurantAddEditViewModel model)
        //    {

        //        RestaurantService service = new RestaurantService();
        //        TryUpdateModel(model);
        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }
        //        Restaurant restaurant;
        //        if (model.Id == 0)
        //        {
        //            restaurant = new Restaurant();
        //        }
        //        else
        //        {
        //            restaurant = service.GetById(model.Id);
        //            if (restaurant == null)
        //            {
        //                return RedirectToAction("List");
        //            }
        //        }

        //        if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
        //        {
        //            var imageExtension = Path.GetExtension(model.ImageUpload.FileName);

        //            if (String.IsNullOrEmpty(imageExtension) || !imageExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
        //            {
        //                ModelState.AddModelError(string.Empty, "Wrong image format.");
        //            }
        //            else
        //            {
        //                string filePath = Server.MapPath("~/Uploads/");
        //                model.ImagePath = model.ImageUpload.FileName;
        //                model.ImageUpload.SaveAs(filePath + model.ImagePath);
        //            }
        //        }
        //        else
        //        {
        //            model.ImagePath = "default.jpg";
        //        }


        //        restaurant.Id = model.Id;
        //        restaurant.Name = model.Name;
        //        restaurant.Address = model.Address;
        //        restaurant.Email = model.Email;
        //        restaurant.Phone = model.Phone;
        //        restaurant.Capacity = model.Capacity;
        //        restaurant.OpenHour = model.OpenHour;
        //        restaurant.CloseHour = model.CloseHour;
        //        restaurant.ImagePath = model.ImagePath;

        //        service.Save(restaurant);
        //        return RedirectToAction("Index");
        //    }

        //    public ActionResult Delete(int? id)
        //{

        //    if (!id.HasValue)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //        RestaurantService service = new RestaurantService();
        //    Restaurant model = new Restaurant();
        //    model = service.GetById(id.Value);
        //    if (model == null || model.IsDeleted)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    service.Delete(model);
        //    return RedirectToAction("Index");
        //}


    }
}