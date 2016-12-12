using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {

        internal BookATableContext context;
        private DbContextTransaction transaction;

        public UnitOfWork()
        {
            this.context = new BookATableContext();
            this.transaction = this.context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }
        }

        public void RollBack()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }
    }
}
