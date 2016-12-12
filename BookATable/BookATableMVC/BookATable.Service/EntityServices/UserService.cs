using BookATable.Service;
using BookATable.Service.EntityServices;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BookATableMVC.Services.EntityServices
{
    public class UserService:BaseService<User>
    {
        public UserService() : base()
        {

        }
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public User GetByGuid(string guid)
        {
            return GetAll().FirstOrDefault(u => u.Email == guid);
        }
        public List<SelectItem> GetSelectedRoles(List<Role> roles)
        {
            roles = roles ?? new List<Role>();
            return new RoleService(this.unitOfWork)
            .GetAll()
            .Select(r => new SelectItem
            {
                Text = r.Name,
                Value = r.Id.ToString(),
                Selected = roles.Any(ar => ar.Id == r.Id)
            })
            .ToList();
        }
        public List<Role> GetUpdatedUserRoles(List<Role> roles, string[] selectedRoles)
        {
            selectedRoles = selectedRoles ?? new string[0];
            roles = roles ?? new List<Role>();
            return roles = new RoleService(this.unitOfWork)
            .GetAll()
            .Where(r => selectedRoles.Any(sr => r.Id == Convert.ToInt32(sr)))
            .ToList();
        }
    }

}