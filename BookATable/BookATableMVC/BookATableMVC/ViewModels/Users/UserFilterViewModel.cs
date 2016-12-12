using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookATableMVC.ViewModels.Users
{
    public class UserFilterViewModel:BaseFilterViewModel<User>
    {
        public override Expression<Func<User, bool>> BuildFilter()
        {
            return x => true;
        }
    }
}