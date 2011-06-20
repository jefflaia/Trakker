using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Transactions;

namespace Trakker.Data.Utilities
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISession _session;
        private ITransaction _transaction;
 
        public UnitOfWork(ISession session)
        {
            session.FlushMode = FlushMode.Auto; //default
        }
 
        public ISession Current
        {
            get { return _session; }
        }

        public void Begin()
        {
            _transaction = _session.BeginTransaction();
        }
 
        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("You must begin a transaction before you can commit");
            }


            //becuase flushMode is auto, this will automatically commit when disposed
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transaction");
            }

            _transaction.Commit();

            //start a new transaction
            _transaction = _session.BeginTransaction();
        }
 
        /// <summary>
        /// Rolls back this instance. You should probably close session.
        /// </summary>
        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("You must begin a transaction before you can rollback");
            }

            if (_transaction.IsActive) _transaction.Rollback();
        }
 
        #region IDisposable Members
 
        public void Dispose()
        {
            if (_session != null)
            {
                _session.Close();
            }
        }
 
        #endregion
    }
}
