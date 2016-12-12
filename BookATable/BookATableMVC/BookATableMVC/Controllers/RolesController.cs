using BookATableMVC.ViewModels.Roles;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookATable.Service.EntityServices;
using BookATableMVC.Helper;
using DAL.Repositories;

namespace BookATableMVC.Controllers
{
    public class RolesController : BaseController<Role, RolesFilterViewModel, RoleListViewModel, RolesEditViewModel>
    {
        // GET: Roles
        public UnitOfWork uow{ get; set; }
        protected override Services.EntityServices.BaseService<Role> CreateService()
        {
            uow = new UnitOfWork();
            return new RoleService(uow);
        }
        protected override void PopulateViewModel(RolesEditViewModel model, Role entity)
        {
            using (uow)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                RoleService service = new RoleService(uow);
                model.AuthActions = SelectListItemMapper.Map(service.GetSelectedActions(entity.AuthActions));
            }
           
        }
        protected override void PopulateEntity(Role entity, RolesEditViewModel model)
        {
            using (uow)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                RoleService service = new RoleService(uow);
                entity.AuthActions = service.GetUpdatedAuthActions(entity.AuthActions, model.SelectedActions);
            }
            
        }

    }
}