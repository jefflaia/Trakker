using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public interface IScriptableComponent
    {

        IAssetManager AssetManager { get; }

        IClientSideObjectWriterFactory ClientSideObjectWriterFactory { get; }

        void WriteInitializationScript(TextWriter writer);

        void WriteCleanupScript(TextWriter writer);
    }
}
