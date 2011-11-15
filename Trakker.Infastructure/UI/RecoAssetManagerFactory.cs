using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Assets;

namespace Trakker.Infastructure.UI
{
    public class RecoAssetManagerFactory : IAssetManagerFactory
    {
        public IAssetManager Create(IStyleSheetAssets styleSheetAssets, IJavaScriptAssets scriptAssets)
        {
            return new RecoAssetAdapter(styleSheetAssets, scriptAssets);
        }
    }
}
