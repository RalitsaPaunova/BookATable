using BookATableMVC.Services.EntityServices;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Service.EntityServices
{
    public class AuthActionService:BaseService<AuthAction>
    {
        public AuthActionService():base()
        {

        }
        public AuthActionService(UnitOfWork unitOfWork):base(unitOfWork)
        {

        }

    }
}
