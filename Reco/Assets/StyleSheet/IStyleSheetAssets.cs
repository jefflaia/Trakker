using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reco.Compressors.StyleSheet;
using Reco.Files;

namespace Reco.Assets
{
    public interface IStyleSheetAssets
    {
        IStyleSheetAssets Combine(bool value);
        IStyleSheetAssets Compress(bool value);
        IStyleSheetAssets Version(bool value);
        IStyleSheetAssets Add(string path);
        IStyleSheetAssets Media(string value);
        IStyleSheetAssets SetCompressor(ICssCompressor compressor);
        IStyleSheetAssets RendererUrl(string url);
        IList<IResource> GetFiles();

        bool Versioned { get; set; }
        bool Combined { get; set; }
        bool Compressed { get; set; }
        string MediaType { get; set; }
        ICssCompressor Compressor { get; set; }
        string GetLastWriteTimestamp();
    }
}
