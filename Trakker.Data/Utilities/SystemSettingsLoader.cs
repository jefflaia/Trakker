using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Reflection;
using Trakker.Data.Repositories;

namespace Trakker.Data.Utilities
{
    public class PropertyBuilder<TEntity>
    {
        private TEntity _entity;
        private IRepository _repo;

        private static IDictionary<Type, PropertyInfo[]> _properties = new Dictionary<Type, PropertyInfo[]>();

        public PropertyBuilder(IRepository repository, TEntity entity)
        {
            _entity = entity;
            _repo = repository;

            CacheProperties(entity);
        }

        public TEntity Build()
        {
            return _entity;

            
        }

        private bool InCache()
        {
            return _properties.ContainsKey(typeof(TEntity));
        }

        private void CacheProperties(TEntity entity)
        {
            if (InCache() == false)
            {   
                _properties.Add(typeof(TEntity), _entity.GetType().GetProperties());
            }
        }
    }
}
