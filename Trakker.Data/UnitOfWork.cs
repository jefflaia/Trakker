using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Transactions;

namespace Trakker.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Commit(ConflictMode conflictMode);
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(IDataContextProvider dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            _dataContext = dataContext.DataContext;
        }

        public void Commit()
        {
            _dataContext.SubmitChanges();
        }

        public void Commit(ConflictMode conflictMode)
        {
            _dataContext.SubmitChanges(conflictMode);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void Rollback()
        {
            _dataContext.Transaction.Rollback();
        }
    }

}
