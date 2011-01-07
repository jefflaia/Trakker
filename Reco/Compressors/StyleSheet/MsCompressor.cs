using Microsoft.Ajax.Utilities;

namespace Reco.Compressors.StyleSheet
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
