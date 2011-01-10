namespace ResourceCompiler.Compressors.StyleSheet
{
    public interface ICssCompressor
    {
        string Identifier { get; }
        string CompressContent(string content);
    }
}