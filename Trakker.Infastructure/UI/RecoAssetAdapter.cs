using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Assets;

namespace Trakker.Infastructure.UI
{
    public class RecoAssetAdapter : IAssetManager
    {
        private IStyleSheetAssets _styleSheetAssets;
        private IJavaScriptAssets _scriptAssets;

        public RecoAssetAdapter(IStyleSheetAssets styleSheetAssets, IJavaScriptAssets scriptAssets)
        {
            _styleSheetAssets = styleSheetAssets;
            _scriptAssets = scriptAssets;
        }

        public void AddStyleSheet(string filename)
        {
            throw new NotImplementedException();
        }

        public void AddScript(string filename)
        {
            throw new NotImplementedException();
        }

        public void AddStyleSheetRange(IEnumerable<string> collection)
        {
            throw new NotImplementedException();
        }

        public void AddScriptRange(IEnumerable<string> collection)
        {
            throw new NotImplementedException();
        }
    }
}
