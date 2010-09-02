using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Trakker.Data
{
    public class DataContextProvider : IDataContextProvider
    {
        private readonly DataContext dataContext;

        public IConnectionStringProvider ConnectionStringProvider { get; private set; }

        public DataContextProvider(IConnectionStringProvider connectionStringProvider)
        {
            ConnectionStringProvider = connectionStringProvider;
            dataContext = new DataContext(ConnectionStringProvider.ConnectionString);
        }

        public DataContext DataContext
        {
            get
            {
                return dataContext;
            }
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
