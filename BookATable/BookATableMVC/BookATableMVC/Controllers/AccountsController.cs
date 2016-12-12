using BookATableMVC.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Entites;
using BookATableMVC.Services.EntityServices;
using BookATableMVC.Helper;
using BookATableMVC.Filters;

namespace BookATableMVC.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserAddEditViewModel model = new UserAddEditViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(UserAddEditViewModel model)
        {
            model.Password = Guid.NewGuid().ToString();
            TryUpdateModel(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User();
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
            user.Phone = model.Phone;

            UserService service = new UserService();
            service.Save(user);

            EmailService.SendRegistrationEmail(user);

            return View(model);
        }
        public ActionResult Verify(string guid)
        {
            UserAddEditViewModel model = new UserAddEditViewModel();
            UserService usersService = new UserService();
            User u = new User();
            u = usersService.GetByGuid(guid);

            model.Id = u.Id;
            model.Name = u.Name;
            model.Email = u.Email;
            model.Password = u.Password;
            model.Phone = u.Phone;

            return View(model);
        }

        [HttpPost]
        public ActionResult Verify()
        {
            UserAddEditViewModel model = new UserAddEditViewModel();
            TryUpdateModel(model);           
            UserService usersService = new UserService();
            User u = usersService.GetById(model.Id);
            u.Id = model.Id;
            u.Name = model.Name;    
            u.Email = model.Email;
            u.Phone = model.Phone;
            if (model.Password==u.Password)
            {
                u.IsVerify = true;
                usersService.Save(u);
                return RedirectToAction("Login", "Accounts");
            }
            else
            {
                return View(model);
            }
                                
        }
        
        public ActionResult Login (string redirectUrl)
        {
            UserAuthenticationViewModel model = new UserAuthenticationViewModel();
            model.RedirectUrl = redirectUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserAuthenticationViewModel model)
        {
            TryUpdateModel(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AthenticationService.Authenticate(model.Email, model.Password);
            if (AthenticationService.LoggedUser != null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            AthenticationService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}