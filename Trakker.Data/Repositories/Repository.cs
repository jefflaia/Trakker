using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Trakker.Data;

namespace Trakker.Data.Repositories
{
    public abstract class Repository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        private DataContext _context;

        protected Repository(DataContext context)
        {
            _context = context;
        }

        protected IQueryable<TEntity> Query
        {
            get { return _context.GetTable<TEntity>(); }
        }

        public TEntity GetById(int id)
        {
            return _context.GetTable<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
        }

        protected void Save(TEntity entity)
        {
            if (entity.Id > 0)
            {
                _context.GetTable<TEntity>().Attach(entity, true);
            }
            else
            {
                _context.GetTable<TEntity>().InsertOnSubmit(entity);
            }

            _context.SubmitChanges();
        }

        protected void Delete(TEntity entity)
        {
            if (entity.Id > 0)
            {
                _context.GetTable<TEntity>().Attach(entity);
                _context.GetTable<TEntity>().DeleteOnSubmit(entity);
                _context.SubmitChanges();
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }

}
