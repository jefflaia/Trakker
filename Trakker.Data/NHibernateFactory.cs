using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using FluentNHibernate.Mapping;
using Trakker.Data.Mappings;

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
                        /*
                        var configuration = new Configuration();
                        configuration.SetNamingStrategy(new PostgresNamingStrategy());
                        
                        configuration.Configure();
                        SchemaMetadataUpdater.QuoteTableAndColumns(configuration);
                        
                        
                        _sessionFactory = configuration.BuildSessionFactory();
                        */
                        string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnectionString"].ConnectionString;
                        IPersistenceConfigurer config = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString);
                        
                        var rawConfig = new NHibernate.Cfg.Configuration();
                        rawConfig.SetNamingStrategy(new PostgresNamingStrategy());

                        FluentConfiguration configuration = Fluently
                            .Configure(rawConfig)
                            .Database(config)
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProjectMap>());

                        configuration.ExposeConfiguration(x => x.SetProperty("hbm2ddl.keywords", "auto-quote"));
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


    internal class PostgresNamingStrategy : INamingStrategy
    {
        public string ClassToTableName(string className)
        {
            return DoubleQuote(className);
        }
        public string PropertyToColumnName(string propertyName)
        {
            return DoubleQuote(propertyName);
        }
        public string TableName(string tableName)
        {
            return DoubleQuote(tableName);
        }
        public string ColumnName(string columnName)
        {
            return DoubleQuote(columnName);
        }
        public string PropertyToTableName(string className,
                                          string propertyName)
        {
            return DoubleQuote(propertyName);
        }
        public string LogicalColumnName(string columnName,
                                        string propertyName)
        {
            return String.IsNullOrWhiteSpace(columnName) ?
                DoubleQuote(propertyName) :
                DoubleQuote(columnName);
        }
        private static string DoubleQuote(string raw)
        {
            // In some cases the identifier is single-quoted.
            // We simply remove the single quotes:
            raw = raw.Replace("`", "");
            return String.Format("\"{0}\"", raw);
        }
    }
}
