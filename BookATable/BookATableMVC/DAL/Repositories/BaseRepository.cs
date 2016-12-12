using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> where T: BaseEntity, new()
    {
        private DbContext db;
        private DbSet<T> dbSet;
        private UnitOfWork unitOfWork;

        public BaseRepository()
        {
            db = new BookATableContext();
            
            //this.unitOfWork = new UnitOfWork();
            //this.db = unitOfWork.context; 
            dbSet = db.Set<T>();
            
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {   
            
            //db = new BookATableContext();
            this.unitOfWork = unitOfWork;
            this.db = unitOfWork.context;
            dbSet = db.Set<T>();
            
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public IQueryable<T> GetAll(Expression<Func<T, Boolean>> expr = null, int page = 0, int itemsPerPage = 0)
        {
            IQueryable<T> result = dbSet;
            if (expr != null)
                result = result.Where(expr);
            if (page > 0 && itemsPerPage > 0)
                result = result.OrderBy(i => i.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            return result;
        }
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }
        protected virtual void Insert(T entity)
        {

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            dbSet.Add(entity);
            db.SaveChanges();   
            
        }
       protected virtual void Update(T entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                dbSet.Attach(entity);
                foreach (PropertyInfo pi in entity.GetType().GetProperties().Where(p => p.GetGetMethod().IsVirtual))
                {
                    db.Entry(entity).Collection(pi.Name).Load();
                }

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public virtual void Save(T entity)
        {
            if (entity.Id > 0)
            {
                Update(entity);
            }
            else
            {   
                Insert(entity);
                
            }
        }
        public virtual void Delete(T entity)
        {

            entity.UpdatedAt = DateTime.Now;
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }
        public int Count(Expression<Func<T, Boolean>> expr = null)
        {
            return expr == null ? this.dbSet.Count() : this.dbSet.Count(expr);
        }
       
    }
}
