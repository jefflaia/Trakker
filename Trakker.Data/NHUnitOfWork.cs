using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Trakker.Data
{
    /*
    public class NHUnitOfWork : INHUnitOfWork
    {
        private ISession context;

        public ISession Context
        {
            get { return StaticSessionManager.SessionFactory.GetCurrentSession(); }
        }

        public NHUnitOfWork()
        {
            this.context = StaticSessionManager.OpenSession();
            CurrentSessionContext.Bind(this.context);

            this.Context.BeginTransaction();
        }

        public void Commit()
        {
            this.Context.Transaction.Commit();
        }

        public void Rollback()
        {
            this.Context.Transaction.Rollback();
        }

        public void Dispose()
        {
            ISession session = CurrentSessionContext.Unbind(StaticSessionManager.SessionFactory);
            session.Close();
        }
    }*/
}
