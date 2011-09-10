using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public interface IClientSideObjectWriterFactory
    {
        IClientSideObjectWriter Create(string id, string type, TextWriter textWriter);
    }
}
