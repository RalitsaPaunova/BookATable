using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels.Users
{
    public class UserAuthenticationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,}$",ErrorMessage="Invalid password!")]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }
        public string RedirectUrl { get; set; }
    }
}