using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RolesRepository : BaseRepository<Role>
    {
        //public RolesRepository()
        //    : base()
        //{

        //}

        //public RolesRepository(UnitOfWork unitOfWork)
        //    : base(unitOfWork)
        //{

        //}
        public bool Exist(int id, string controller, string action)
        {
            //AuthControllerRepository authcontrollerrepo = new AuthControllerRepository();
            //List<AuthController> authcontrollers = authcontrollerrepo.GetAll(c => c.Name == controller).ToList();
            //foreach (var item in authcontrollers)
            //{
            //    for (int i = 0; i < item.AuthActions.Count; i++)
            //    {
            //        for (int y = 0; y < item.AuthActions[i].Roles.Count; y++)
            //        {
            //            if (item.AuthActions[i].Roles[y].Id == id)
            //            {
            //                return true;
            //            }

            //        }
            //    }
            //}
            //return false;

            Role role = new Role();
            role = this.GetById(id);
            List<AuthAction> actions = role.AuthActions;
            List<AuthAction> actionsByName = actions.Where(i => i.Name == action).ToList();
            return actionsByName.Any(c => c.AuthController.Name == controller);

        }

    }

}
