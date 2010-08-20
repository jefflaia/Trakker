using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Trakker.Data
{
    public interface IDataContextProvider : IDisposable
    {
        DataContext DataContext { get; }
    }
}
