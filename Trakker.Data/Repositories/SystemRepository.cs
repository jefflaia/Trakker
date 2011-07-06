namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;
    using System.Globalization;
    using System.Reflection;
    using NHibernate;

    public class SystemRepository : Repository, ISystemRepository
    {

        public SystemRepository(ISession session) : base (session)
        {

        }

        public Property GetPropertyByKey<T>(string key)
        {
            return GetSingleBy<Property>(m => m.Identifier, key);
        }

        public void Save(Property property)
        {
            base.Save(property);
        }

        public void Save(File file)
        {
            base.Save(file);
        }
    }
}
