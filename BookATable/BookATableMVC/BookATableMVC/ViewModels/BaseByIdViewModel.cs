using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels
{
    public abstract class BaseByIdViewModel
    {
        public int Id { get; set; }
    }
}