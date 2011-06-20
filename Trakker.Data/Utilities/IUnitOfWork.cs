using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Trakker.Data.Utilities
{
    public interface IUnitOfWork : IDisposable
    {
         ISession Current { get; }
         void Begin();
         void Commit();
         void Rollback();
    }
}
