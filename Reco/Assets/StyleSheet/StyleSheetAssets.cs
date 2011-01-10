using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Compressors.StyleSheet;
using System.Web;
using System.IO;
using ResourceCompiler.FileResolvers;
using ResourceCompiler.Files;
using ResourceCompiler.Assets;

namespace ResourceCompiler.Assets
{


    public class StyleSheetAssets : Assets, IStyleSheetAssets
    {
        protected ICssCompressor _cssCompressor;
        
        public StyleSheetAssets() : base()
        {
            MediaType = "screen";
            Compressor = new NullCompressor();
            _files = new List<IResource>();
        }

        public StyleSheetAssets(ICssCompressor compressor)
            : base()
        {
            MediaType = "screen";
            Compressor = compressor;
        }

        public bool Versioned { get; set; }
        public bool Combined { get; set; }
        public bool Compressed { get; set; }
        public string MediaType { get; set; }
        public ICssCompressor Compressor { get; set; }

        public IStyleSheetAssets Add(string path)
        {
            FileResolver resolver = new FileResolver();
            IResource file = new Resource( resolver.Resolve(path), FileResolver.Type);

            if (FileExists(file) == false)
            {
                if (file.Exists())
                {
                    AddResource(file);
                }
                else
                {
                    throw new FileNotFoundException(string.Format("File \"{0}\" could not be found.", path));
                }
            }

            return this;
        }

        public IStyleSheetAssets Compress(bool value)
        {
            Compressed = value;
            return this;
        }

        public IStyleSheetAssets Combine(bool value)
        {
            Combined = value;
            return this;
        }

        public IStyleSheetAssets Version(bool value)
        {
            Versioned = value;
            return this;
        }

        public IStyleSheetAssets Media(string value)
        {
            MediaType = value;
            return this;
        }

        public IStyleSheetAssets RendererUrl(string url)
        {
            Route = url;
            return this;
        }

        public IStyleSheetAssets SetCompressor(ICssCompressor compressor)
        {
            _cssCompressor = compressor;
            return this;
        }

    }
}
