using BookATableMVC.Helper.EntityServices;
using BookATableMVC.ViewModels.Reservations;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookATable.Service.EntityServices;

using BookATableMVC.Helper;
using BookATableMVC.Services.EntityServices;

namespace BookATableMVC.Controllers
{
    public class ReservationsController : BaseController<Reservation, ReservationFilterViewModel,ReservationListViewModel, ReservationAddEditViewModel>
    {
        //    // GET: Reservations
        //    public ActionResult Index()
        //    {
        //        ReservationListViewModel model = new ReservationListViewModel();

        //        model.Reservations = new ReservationService().GetAll(u => u.UserId == AthenticationService.LoggedUser.Id).ToList();
        //        if (model.Reservations == null)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        return View(model);
        //    }       
        protected override BaseService<Reservation> CreateService()
        {
            return new ReservationService();
        }

        protected override void PopulateViewModel(ReservationAddEditViewModel model, Reservation reservation)
        {
            model.Id = reservation.Id;
            model.UserId = AthenticationService.LoggedUser.Id;
            model.RestaurantId = reservation.RestaurantId;
            model.Comment = reservation.Comment;
            model.PeopleCount = reservation.PeopleCount;
            model.ReservationTime = reservation.ReservationTime;
            
        }

        protected override void PopulateEntity(Reservation reservation, ReservationAddEditViewModel model)
        {
            reservation.Id = model.Id;
            reservation.UserId = model.UserId;
            reservation.RestaurantId = model.RestaurantId;
            reservation.Comment = model.Comment;
            reservation.PeopleCount = model.PeopleCount;
            reservation.ReservationTime = model.ReservationTime;

            ReservationService service = new ReservationService();
            RestaurantService restService = new RestaurantService();
           

            if (!service.CheckFreeSeats(reservation))
            {
                ModelState.AddModelError("PeopleCount", "There are no free seats");
              
                //return View(model);
            }
            else
            {
                service.Save(reservation);
                // return RedirectToAction("Index");
            }
        }

        //public ActionResult Edit(int? id)
        //{
        //    Reservation reservation;

        //    if (!id.HasValue)
        //    {
        //        reservation = new Reservation();
        //    }
        //    else
        //    {
        //        ReservationService service = new ReservationService();
        //        reservation = service.GetById(id.Value);
        //        if (reservation == null)
        //        {
        //            RedirectToAction("Index");
        //        }
        //    }

        //    ReservationAddEditViewModel model = new ReservationAddEditViewModel();
        //    model.Id = reservation.Id;
        //    model.UserId = AthenticationService.LoggedUser.Id;
        //    model.RestaurantId = reservation.RestaurantId;
        //    model.Comment = reservation.Comment;
        //    model.PeopleCount = reservation.PeopleCount;
        //    model.ReservationTime = reservation.ReservationTime;
        //    model.Restaurants = GetRestaurants();

        //    return View(model);
        //}

        //[HttpPost]
        //public override ActionResult Edit(ReservationAddEditViewModel model)
        //{
        //    TryUpdateModel(model);
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    ReservationService service = new ReservationService();
        //    Reservation reservation;
        //    if (model.Id == 0)
        //    {
        //        reservation = new Reservation();
        //    }
        //    else
        //    {
        //        reservation = service.GetById(model.Id);
        //        if (reservation == null)
        //        {                    
        //            return RedirectToAction("List");
        //        }
        //    }

        //    reservation.Id = model.Id;
        //    reservation.UserId = model.UserId;
        //    reservation.RestaurantId = model.RestaurantId;
        //    reservation.Comment = model.Comment;
        //    reservation.PeopleCount = model.PeopleCount;
        //    reservation.ReservationTime = model.ReservationTime;
        //    Reservation reservation = new Reservation();
        //    ReservationService service = new ReservationService();
        //    RestaurantService restService = new RestaurantService();
        //    reservation.RestaurantName = restService.GetById((model.RestaurantId)).Name;

        //    if (!service.CheckFreeSeats(reservation))
        //    {
        //        ModelState.AddModelError("PeopleCount", "There are no free seats");
        //        model.Restaurants = GetRestaurants();
        //        return View(model);
        //    }
        //    else
        //    {
        //        service.Save(reservation);
        //        return RedirectToAction("Index");
        //    }
        //}

        //public ActionResult Delete(int? id)
        //{
        //    ReservationService service = new ReservationService();
        //    Reservation model = service.GetById(id.Value);
        //    if (model == null || model.IsDeleted)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    service.Delete(model);
        //    return RedirectToAction("Index");
        //}
    }
}