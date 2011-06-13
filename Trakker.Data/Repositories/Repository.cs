using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Trakker.Data;
using Trakker.Core;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using System.Reflection;

namespace Trakker.Data.Repositories
{
    public abstract class Repository : IRepository
    {
        protected ISession Session { get; set; }

        public Repository(ISession session)
        {
            Session = session;
        }

        public TEntity GetById<TEntity>(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public IList<TEntity> GetAll<TEntity>()
        {
            return Session.CreateCriteria(typeof(TEntity)).List<TEntity>();
        }

        public IList<TEntity> GetAll<TEntity>(int limit)
        {
            return Session.CreateCriteria(typeof(TEntity))
                .SetMaxResults(limit)
                .List<TEntity>();
        }

        public Paginated<TEntity> GetPaginated<TEntity>(int page, int pageSize)
        {
            // Get the total row count in the database.
            var rowCount = this.Session.CreateCriteria(typeof(TEntity))
                .SetProjection(Projections.RowCount()).FutureValue<Int32>();

            // Get the actual log entries, respecting the paging.
            var items = this.Session.CreateCriteria(typeof(TEntity))
                .SetFirstResult(page * pageSize)
                .SetMaxResults(pageSize)
                .Future<TEntity>();

            return new Paginated<TEntity>
            {
                Items = items.ToList<TEntity>(),
                Index = page,
                TotalItems = rowCount.Value
            };

        }

        public Paginated<TEntity> GetPaginated<TEntity>(ICriteria criteria, int page, int pageSize)
        {

            ICriteria criteriaCount = CriteriaTransformer.Clone(criteria);
            criteriaCount.ClearOrders();

            // Get the total row count in the database.
            int rowCount = criteriaCount
                .SetProjection(Projections.RowCount())
                .UniqueResult<Int32>();

            // Get the actual log entries, respecting the paging.
            IList<TEntity> items = criteria
                .SetFirstResult(page * pageSize)
                .SetMaxResults(pageSize)
                .List<TEntity>();

            return new Paginated<TEntity>
            {
                Items = items,
                Index = page,
                TotalItems = rowCount
            };
        }        

        public TEntity GetSingleBy<TEntity>(Expression<Func<TEntity, object>> expression, object value)
        {
            string propertyName = expression.GetPropertyName();

            return Session.CreateCriteria(typeof(TEntity))
                .Add(Restrictions.Eq(propertyName, value))
                .UniqueResult<TEntity>();
        }

        public IList<TEntity> GetManyBy<TEntity>(Expression<Func<TEntity, object>> expression, object value)
        {
            string propertyName = expression.GetPropertyName();

            return Session.CreateCriteria(typeof(TEntity))
                .Add(Restrictions.Eq(propertyName, value))
                .List<TEntity>();
        }
        
        public void Delete(object entity)
        {
            Session.Delete(entity);
        }

        public void Save(object entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }

}
