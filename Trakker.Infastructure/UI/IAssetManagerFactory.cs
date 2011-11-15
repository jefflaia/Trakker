using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Assets;

namespace Trakker.Infastructure.UI
{
    public interface IAssetManagerFactory
    {
        IAssetManager Create(IStyleSheetAssets styleSheetAssets, IJavaScriptAssets scriptAssets);
    }
}
