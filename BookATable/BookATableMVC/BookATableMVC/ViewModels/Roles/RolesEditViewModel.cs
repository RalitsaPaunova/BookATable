using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.ViewModels.Roles
{
    public class RolesEditViewModel:BaseByIdViewModel
    {
        [Display(Name="Role Name")]
        public string Name { get; set; }
        public virtual List<SelectListItem> AuthActions { get; set; }
        public string[] SelectedActions { get; set; }
    }
}