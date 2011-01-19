using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Assets;
using System.Web;
using ResourceCompiler.Files;
using ResourceCompiler.Utilities;

namespace ResourceCompiler.Renderers
{
    public class StyleSheetRenderer : IStyleSheetRenderer
    {
        private readonly IStyleSheetAssets _assets;
        protected const string _template = "<link rel=\"stylesheet\" type=\"text/css\" {0} href=\"{1}\" />";

        public StyleSheetRenderer(IStyleSheetAssets assets)
        {
            _assets = assets;
        }
        
        public string Render()
        {
            string media = "media=\"{0}\"";
            string version = string.Empty;
            string url = "{0}?v={1}";

            if (_assets.Versioned)
            {
                version = _assets.GetLastWriteTimestamp();
            }


            media = string.Format(media, _assets.MediaType);
            url = string.Format(url, "", version);

            return String.Format(_template, media, url);
        }

        public string Generate()
        {
            StringBuilder content = new StringBuilder();
            string outputContent = String.Empty;

            foreach (var file in _assets.GetFiles())
            {
                string styleSheetContent = GetResourceContent(file);
                styleSheetContent = StyleSheetPathRewriter.RewriteCssPaths(AppDomain.CurrentDomain.BaseDirectory + "Content", file.Path, styleSheetContent);
                content.Append(styleSheetContent);
            }

            outputContent = content.ToString();
            if (_assets.Compressed)
            {
                outputContent = CompressContent(content.ToString());
            }

            return outputContent;
        }

        private string GetResourceContent(IResource resource)
        {
            FileReader reader = new FileReader(resource.Path);
            return reader.ReadToEnd();
        }

        private string CompressContent(string content)
        {
            return _assets.Compressor.CompressContent(content);
        }

        private bool CanGZip(HttpRequest request)
        {
            string acceptEncoding = request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(acceptEncoding) &&
                (acceptEncoding.Contains("gzip") || acceptEncoding.Contains("deflate")))
            {
                return true;
            }
            return false;
        }
    }
}
