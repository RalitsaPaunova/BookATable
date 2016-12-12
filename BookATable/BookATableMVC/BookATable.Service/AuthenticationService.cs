using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;
using DAL.Repositories;
using BookATableMVC.Services.EntityServices;

namespace BookATable.Service
{
    public class AuthenticationService
    {
        public  User LoggedUser { get; set; }
        public void Authenticate(string email, string password)
        {
            LoggedUser = new UserService().GetAll().FirstOrDefault(u => u.Email == email && u.Password == password && u.IsVerify == true);
        }
    }
}
