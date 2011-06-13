namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;

    using Sql = Access;
    using System.Globalization;
    using System.Reflection;
    using NHibernate;

    public class SystemRepository : Repository, ISystemRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.ColorPalette> _paletteTable;
        private Table<Sql.Property> _propertyTable;

        internal class Setting
        {
            public String Key { get; set; }
            public String Value { get; set; }
        }

        public SystemRepository(IDataContextProvider dataContext, ISession session) : base (session)
        {
            _dataContext = dataContext.DataContext;
            _paletteTable = _dataContext.GetTable<Sql.ColorPalette>();
            _propertyTable = _dataContext.GetTable<Sql.Property>();

        }

        
        public Property<T> GetPropertyByName<T>(string name)
        {
            var property = (from p in _propertyTable
                where p.Identifier == name
                select p).SingleOrDefault() ?? null;

            Property<T> typeProperty = new Property<T>
            {
                Id = property.Id,
                Name = property.Name,
                Created = property.Created,
                Identifier = property.Identifier,
                Type = property.Type,
                Value = (T)Convert.ChangeType(property.Value, typeof(T)),

            };

            return typeProperty;
        }

        public void Save<T>(Property<T> property)
        {
            Sql.Property rowProperty = new Sql.Property
            {
                Id = property.Id,
                Name = property.Name,
                Identifier = property.Identifier,
                Created = property.Created,
                Type = property.Type,
                Value = property.Value.ToString()
            };

            if (rowProperty.Id == 0)
            {
                _propertyTable.InsertOnSubmit(rowProperty);
            }
            else
            {
                _propertyTable.Attach(rowProperty);
                _propertyTable.Context.Refresh(RefreshMode.KeepCurrentValues, rowProperty);
            }

            property.Id = rowProperty.Id;
        }
    }
}
