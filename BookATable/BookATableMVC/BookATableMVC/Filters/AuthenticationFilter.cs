using BookATableMVC.Helper;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.Filters
{
    public class AuthenticationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AthenticationService.LoggedUser == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Accounts/Login?redirectUrl=" + filterContext.HttpContext.Request.Url);
                //filterContext.Result = new EmptyResult();              
            }
        }
    }
}