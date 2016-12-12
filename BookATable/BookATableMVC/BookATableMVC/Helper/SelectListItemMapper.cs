using BookATable.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATableMVC.Helper
{
    public class SelectListItemMapper
    {
        public static List<SelectListItem> Map(List<SelectItem> list)
        {
            return list.Select(i => new SelectListItem
                {
                    Text = i.Text,
                    Value = i.Value,
                    Selected = i.Selected
                }).ToList();
        }
    }
}