using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.Tools
{
    public class FilterPropertyAttribute:Attribute
    {
        public string DisplayName { get; set; }
    }
}