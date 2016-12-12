using BookATableMVC.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Entites;
using BookATableMVC.Helper;
using BookATableMVC.Services.EntityServices;
using BookATableMVC.Filters;
using DAL.Repositories;

namespace BookATableMVC.Controllers
{
    public class UserController:BaseController<User,UserFilterViewModel, UserListViewModel,UserAddEditViewModel>
    {
        public UnitOfWork uow { get; set; }
        

        protected override BaseService<User> CreateService()
        {
            uow = new UnitOfWork();
            return  new UserService(uow);
        }
        protected override void PopulateViewModel(UserAddEditViewModel model, User entity)
        {
            using (uow)
            {
                model.Id = entity.Id;
                model.Email = entity.Email;
                model.Name = entity.Name;
                model.Password = entity.Password;
                model.Phone = entity.Phone;
                UserService service = new UserService(uow);
                model.Roles = SelectListItemMapper.Map(service.GetSelectedRoles(entity.Roles));
 
            }
            
        }
        protected override void PopulateEntity(User entity, UserAddEditViewModel model)
        {
            using (uow)
            {
                entity.Id = model.Id;
                entity.Email = model.Email;
                entity.Password = model.Password;
                entity.Name = model.Name;
                entity.Phone = model.Phone;
                entity.IsVerify = true;
                UserService service = new UserService(uow);
                entity.Roles = service.GetUpdatedUserRoles(entity.Roles, model.SelectedRoles); 
            }
            
        }
    }
}