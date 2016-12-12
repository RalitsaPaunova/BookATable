using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BookATableMVC.Helper
{
    public static class EmailService
    {
        public static void SendRegistrationEmail(User u)
        {
            try { 
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("no-reply@management.com");
            mail.Subject = "Registration successfull";
            mail.To.Add(u.Email);
            mail.Body = "Hello " + u.Name + Environment.NewLine
                + "Thank you for registering. Confirm your registration by visiting the following link: "
                + Environment.NewLine
                + "http://localhost:" + HttpContext.Current.Request.Url.Port + "/Accounts/Verify?guid=" + u.Password;

            SmtpClient smtp = new SmtpClient("smtp.live.com", 25);
            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;
            #region Private
            smtp.Credentials = new System.Net.NetworkCredential("dimitrieva_martina@hotmail.com", "karapu4ev");
            #endregion

            smtp.Send(mail);
                }
            catch (Exception e)
            {
                throw e ;
            }
        }
      
    }
}