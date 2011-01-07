using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reco.Renderers;

namespace Reco
{
    public class Reco
    {
        public IStyleSheetRenderer StyleSheet()
        {
            return new StyleSheetRenderer(RecoAssets.StyleSheet());
        }
    }
}
