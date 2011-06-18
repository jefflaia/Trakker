using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Trakker.Data
{
    public interface INHUnitOfWork : IDisposable
    {
         ISession Context { get; }
         void Commit();
         void Rollback();
    }
}
