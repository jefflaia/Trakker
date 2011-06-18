using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NHibernate.Criterion;
using NHibernate;

namespace Trakker.Data.Repositories
{
    public interface IRepository : IDisposable
    {
        TEntity GetById<TEntity>(int id);

        IList<TEntity> GetAll<TEntity>();
        IList<TEntity> GetAll<TEntity>(int limit);

        Paginated<TEntity> GetPaginated<TEntity>(int page, int pageSize);
        Paginated<TEntity> GetPaginated<TEntity>(ICriteria criteria, int page, int pageSize);

        TEntity GetSingleBy<TEntity>(Expression<Func<TEntity, object>> expression, object value);
        IList<TEntity> GetManyBy<TEntity>(Expression<Func<TEntity, object>> expression, object value);

        void Delete(object entity);
        void Save(object entity);
    }
}
