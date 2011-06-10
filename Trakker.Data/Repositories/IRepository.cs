using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using NHibernate.Criterion;

namespace Trakker.Data
{
    public interface IRepository : IDisposable
    {
        TEntity GetById<TEntity>(int id);

        IList<TEntity> GetAll<TEntity>();
        IList<TEntity> GetAll<TEntity>(int limit);

        Paginated<TEntity> GetAllPaginated<TEntity>(int page, int pageSize);
        Paginated<TEntity> GetPaginated<TEntity>(ICriterion criterion, int page, int pageSize);

        TEntity GetBy<TEntity>(Expression<Func<TEntity, object>> expression, object value);

        void Delete(object entity);
        void Save(object entity);
    }
}
