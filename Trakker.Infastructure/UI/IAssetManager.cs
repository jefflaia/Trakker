using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public interface IAssetManager
    {
        void AddStyleSheet(string filename);
        void AddScript(string filename);

        void AddStyleSheetRange(IEnumerable<string> collection);
        void AddScriptRange(IEnumerable<string> collection);
    }
}
