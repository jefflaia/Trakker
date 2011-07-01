using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Trakker.Data
{
    public class NHibernateFactory
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                try 
                {
                    if (_sessionFactory == null)
                    {
                        var configuration = new Configuration();
                        configuration.Configure();
                        _sessionFactory = configuration.BuildSessionFactory();
                    }
                    return _sessionFactory;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    throw new Exception("NHibernate initialization failed", ex);
                }
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
