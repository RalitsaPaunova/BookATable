using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Repositories;
using System.Linq.Expressions;

namespace BookATableMVC.Services.EntityServices
{
    public class BaseService<T> where T: BaseEntity, new()
    {
        private BaseRepository<T> Repository;
        protected UnitOfWork unitOfWork;

        public BaseService()
        {
            
            this.Repository = new BaseRepository<T>();
        }

        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = new BaseRepository<T>(this.unitOfWork);

        }
        public IEnumerable<T> GetAll()
        {
            return this.Repository.GetAll();
        }
        public IQueryable<T> GetAll(Expression<Func<T, Boolean>> expr = null, int page = 0, int itemsPerPage = 0)
        {
            return this.Repository.GetAll(expr, page, itemsPerPage);
        }
        public T GetById(int id)
        {
            return this.Repository.GetById(id);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return this.Get(filter);
        }
        public void Save(T entity)
        {
            this.Repository.Save(entity);
        }
        public void Delete(T entity)
        {
            this.Repository.Delete(entity);
        }
        public int Count(Expression<Func<T, Boolean>> expr = null)
        {
            return this.Repository.Count(expr);
        }
    }
}