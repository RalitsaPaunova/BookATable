using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookATableMVC.ViewModels
{
    public abstract class BaseFilterViewModel<T>
        where T:BaseEntity
    {
        public string Prefix { get; set; }
        public PagerViewModel ParentPager { get; set; }
        public abstract Expression<Func<T, Boolean>> BuildFilter();
    }
}