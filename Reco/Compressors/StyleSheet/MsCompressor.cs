using Microsoft.Ajax.Utilities;

namespace ResourceCompiler.Compressors.StyleSheet
{
    public class MsCompressor: ICssCompressor
    {
        public static string Identifier
        {
            get { return "MsCompressor"; }
        }

        public string CompressContent(string content)
        {
            var minifier = new Minifier();
            return minifier.MinifyStyleSheet(content);
        }

        string ICssCompressor.Identifier
        {
            get { return Identifier; }
        }
    }
}
