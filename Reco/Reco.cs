using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Renderers;

namespace ResourceCompiler
{
    public static class Reco
    {
        public static IStyleSheetRenderer StyleSheet()
        {
            return new StyleSheetRenderer(RecoAssets.StyleSheet());
        }
    }
}
