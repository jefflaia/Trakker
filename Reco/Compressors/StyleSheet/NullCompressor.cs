namespace Reco.Compressors.StyleSheet
{
    public class NullCompressor: ICssCompressor
    {
        public static string Identifier
        {
            get { return "NullCompressor"; }
        }

        public string CompressContent(string content)
        {
            return content;
        }

        string ICssCompressor.Identifier
        {
            get { return Identifier; }
        }        
    }
}