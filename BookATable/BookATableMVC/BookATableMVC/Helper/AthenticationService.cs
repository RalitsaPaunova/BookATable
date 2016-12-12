using BookATable.Service;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.Helper
{
    public static class AthenticationService
    {
        public static AuthenticationService AuthenticationServiceInstance //http context 
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session[typeof(AuthenticationService).Name]==null)
                {
                    HttpContext.Current.Session[typeof(AuthenticationService).Name] = new AuthenticationService();
                }
                return(AuthenticationService) HttpContext.Current.Session[typeof(AuthenticationService).Name];
            }
        }
        public static User LoggedUser
        {
            get
            {                
                return AuthenticationServiceInstance.LoggedUser;
            }
        }
        public static void Authenticate(string email, string password)
        {
            AuthenticationServiceInstance.Authenticate(email, password);
        }
        public static void Logout()
        {
            Authenticate(null, null);
        }
    }
}