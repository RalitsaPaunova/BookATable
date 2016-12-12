using BookATable.Service.EntityServices;
using BookATableMVC.Helper.EntityServices;
using BookATableMVC.Services.EntityServices;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}