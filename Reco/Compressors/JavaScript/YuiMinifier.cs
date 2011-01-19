using System;
using Yahoo.Yui.Compressor;
using System.Text;
using System.Globalization;
using ResourceCompiler.JavaScript.Minifiers;

namespace Reco.JavaScript.Minifiers
{
    public class YuiMinifier: IJavaScriptCompressor
    {
        string IJavaScriptCompressor.Identifier
        {
            get { return Identifier; }
        }
        
        public static string Identifier
        {
            get { return "YuiJavaScriptCompressor"; }
        }

        public string CompressContent(string content)
        {
            return JavaScriptCompressor.Compress(content, true, true, false, false, -1, Encoding.UTF8, CultureInfo.InvariantCulture, false);
        }
    }
}