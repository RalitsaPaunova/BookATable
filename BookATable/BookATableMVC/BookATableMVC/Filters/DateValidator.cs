using BookATable.Service.EntityServices;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableMVC.Filters
{
    public class DateValidator:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, DateTime.Now) != 1)
            {
                this.ErrorMessage = "The date is invalid.Try again!";
                return false;
            }
            return true;
        }

    }
}