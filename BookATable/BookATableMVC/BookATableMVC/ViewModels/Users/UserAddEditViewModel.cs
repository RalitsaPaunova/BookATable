using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.ViewModels.Users
{
    public class UserAddEditViewModel:BaseByIdViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,}$",ErrorMessage = "The password must include at least one capital letter, one small letter and one digit!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "The password must be minimum 8 characters!")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-z\s\'\-]*$", ErrorMessage = "The name can contain letters or hyphen(-), apostrophe(‘)!")]
        public string Name { get; set; }
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)\[\]]*$")]
        public string Phone { get; set; }
        public bool IsVerify { get; set; }

        public List<SelectListItem> Roles { get; set; }
        public string[] SelectedRoles { get; set; }
    }
}