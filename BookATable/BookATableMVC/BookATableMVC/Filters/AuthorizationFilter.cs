using BookATableMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using DAL.Entites;
using DAL.Repositories;
namespace BookATableMVC.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (AthenticationService.LoggedUser == null)
            //{
            //    filterContext.HttpContext.Response.Redirect("~/Accounts/Login?redirectUrl=" + filterContext.HttpContext.Request.Url);
            //    filterContext.Result = new EmptyResult();

            //}
            //else
            //{
                RolesRepository rolesRepo = new RolesRepository();
                string controllerName = filterContext.RouteData.Values[typeof(Controller).Name].ToString() + typeof(Controller).Name;
                string actionName = filterContext.RouteData.Values[typeof(Action).Name].ToString();

                foreach (var role in AthenticationService.LoggedUser.Roles)
                {
                    if (rolesRepo.Exist(role.Id, controllerName, actionName))
                    {
                        base.OnActionExecuting(filterContext);
                        return;
                    }
                }
                filterContext.Result = new RedirectResult("~/");
            //}
        }
    }
}