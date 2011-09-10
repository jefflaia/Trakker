using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class ClientSideObjectWriterFactory : IClientSideObjectWriterFactory
    {
        public IClientSideObjectWriter Create(string id, string type, TextWriter textWriter)
        {
            return new ClientSideObjectWriter(id, type, textWriter);
        }
    }
}
