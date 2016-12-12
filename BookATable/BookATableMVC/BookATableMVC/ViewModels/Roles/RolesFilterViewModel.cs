using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableMVC.ViewModels.Roles
{
    public class RolesFilterViewModel:BaseFilterViewModel<Role>
    {

        public override System.Linq.Expressions.Expression<Func<Role, bool>> BuildFilter()
        {
            return x => true;
        }
    }
}