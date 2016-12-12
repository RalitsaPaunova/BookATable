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
    public class RoleService:BaseService<Role>
    {
        public RoleService()
        {

        }
        public RoleService(UnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        public List<SelectItem> GetSelectedActions(List<AuthAction> actions)
        {
            actions = actions ?? new List<AuthAction>();
            return new AuthActionService(this.unitOfWork)
            .GetAll()
            .Select(a => new SelectItem
            {
                Text = a.Name+" ["+a.MethodType+"]" + " " + a.AuthController.Name,
                Value = a.Id.ToString(),
                Selected = actions.Any(ar => ar.Id == a.Id)
            })
            .ToList();
        }
        public List<AuthAction> GetUpdatedAuthActions(List<AuthAction> actions, string[] selectedActions)
        {
            selectedActions = selectedActions ?? new string[0];
            actions = actions ?? new List<AuthAction>();
            return actions = new AuthActionService(this.unitOfWork)
            .GetAll()
            .Where(a => selectedActions.Any(sr => a.Id == Convert.ToInt32(sr)))
            .ToList();
        }
    }
}
