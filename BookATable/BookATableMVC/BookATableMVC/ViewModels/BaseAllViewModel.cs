using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels
{
    public class BaseAllViewModel<T,F>
        where T : BaseEntity
        where F : BaseFilterViewModel<T>
    {
        public IList<T> Items { get; set; }

        public PagerViewModel Pager { get; set; }

        public F Filter { get; set; }
    }
}