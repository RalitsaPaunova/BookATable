using BookATableMVC.ViewModels.Restaurants;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using BookATableMVC.Helper;
using BookATableMVC.ViewModels;
using BookATableMVC.Services.EntityServices;
using BookATableMVC.Filters;

namespace BookATableMVC.Controllers
{
    [AuthenticationFilter]
    [AuthorizationFilter]
    public abstract class BaseController<T, FilterVM, LVM, BID> : Controller 
        where T : BaseEntity, new()
        where FilterVM : BaseFilterViewModel<T>, new()
        where LVM : BaseAllViewModel<T, FilterVM>, new() 
        where BID : BaseByIdViewModel, new()
    {
        private BaseService<T> service;
        public BaseController()
        {
            service = CreateService();
        }
        protected abstract BaseService<T> CreateService();

        protected virtual ActionResult Redirect(T entity)
        {
            return RedirectToAction("Index");
        }
        // GET: Base
        public ActionResult Index()
        {
            if (AthenticationService.LoggedUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            LVM model = new LVM();
            TryUpdateModel(model);

            string controllerName = GetController();
            string actionName = GetAction();

            model.Pager = new PagerViewModel();
            model.Filter = new FilterVM();
            TryUpdateModel(model);

            model.Filter.Prefix = "Filter.";
            int resultCount = service.Count(model.Filter.BuildFilter()); 
            string prefix = "Pager.";
            
            model.Pager = new PagerViewModel(resultCount, model.Pager.CurrentPage, model.Pager.PageSize, prefix, actionName, controllerName);
            model.Filter.ParentPager = model.Pager;           
            model.Items = service.GetAll(model.Filter.BuildFilter(), model.Pager.CurrentPage, model.Pager.PageSize.Value).ToList();
            
            return View(model);
        }
        protected string GetAction()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }
        protected string GetController()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        protected virtual void DeleteFilter(int id)
        {
        }

        protected virtual void PopulateViewModel(BID model, T entity)
        {
        }

        protected virtual void PopulateEntity(T entity, BID model)
        {
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            T entity = (id == null || id <= 0) ? new T() : service.GetById(id.Value);
            BID model = new BID();
            PopulateViewModel(model, entity);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            BID model = new BID();
            TryUpdateModel(model);
            T entity = new T();
            if (ModelState.IsValid)
            {
                PopulateEntity(entity, model);
                service.Save(entity);
                return Redirect(entity);
            }
            else
            {
                PopulateEntity(entity,model);
                return View(model);
            }
            
        }

        public ActionResult Delete(int id)
        {
            T entity = service.GetById(id);
            service.Delete(entity);
            // DeleteFilter(id);
            return Redirect(entity);

        }
    }
}