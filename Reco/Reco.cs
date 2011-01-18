using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Renderers;
using ResourceCompiler.Assets;

namespace ResourceCompiler
{
    public static class Reco
    {
        private static string _template = "<link rel=\"stylesheet\" type=\"text/css\" {0} href=\"{1}\" />";

        public static IStyleSheetRenderer StyleSheet()
        {
            return new StyleSheetRenderer(RecoAssets.StyleSheet());
        }

        public static string Link()
        {
            IStyleSheetAssets assets = RecoAssets.StyleSheet();
            assets.GetLastWriteTimestamp();

            string media = "media=\"{0}\"";
            string version = string.Empty;
            string url = "{0}?v={1}";

            if (assets.Versioned)
            {
                version = assets.GetLastWriteTimestamp();
            }

            media = string.Format(media, assets.MediaType);
            url = string.Format(url, "generated.css", version);

            return String.Format(_template, media, url);
        }
    }
}
