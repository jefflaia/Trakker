using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public interface IScriptableComponent
    {
        /// <summary>
        /// Gets or sets the asset key.
        /// </summary>
        /// <value>The asset key.</value>
        string AssetKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the script files path. Path must be a virtual path.
        /// </summary>
        /// <value>The script files path.</value>
        string ScriptFilesPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the script file names.
        /// </summary>
        /// <value>The script file names.</value>
        IList<string> ScriptFileNames
        {
            get;
        }


        IClientSideObjectWriterFactory ClientSideObjectWriterFactory
        {
            get;
        }

        bool IsSelfInitialized
        {
            get;
        }

        void WriteInitializationScript(TextWriter writer);

        void WriteCleanupScript(TextWriter writer);
    }
}
