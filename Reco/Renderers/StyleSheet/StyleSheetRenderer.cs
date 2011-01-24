using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceCompiler.Assets;
using System.Web;
using ResourceCompiler.Files;
using ResourceCompiler.Utilities;
using ResourceCompiler.Resolvers;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ResourceCompiler.Renderers
{
    public class StyleSheetRenderer : IStyleSheetRenderer
    {
        private readonly IStyleSheetAssets _assets;

        //probably change this to a hashtable
        private IDictionary<string, string> _modelProperties;

        public StyleSheetRenderer(IStyleSheetAssets assets)
        {
            _assets = assets;
        }
        
        public string Generate()
        {
            StringBuilder content = new StringBuilder();
            string outputContent = String.Empty;

            foreach (var file in _assets.GetFiles())
            {
                string styleSheetContent = GetResourceContent(file);

                if (String.Compare(file.Type, DynamicFileResolver.Type) == 0)
                {
                    ApplyModel(styleSheetContent);
                }

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

        public object Model { get; set; }

        private string GetResourceContent(IResource resource)
        {
            FileReader reader = new FileReader(resource.Path);
            return reader.ReadToEnd();
        }

        private string CompressContent(string content)
        {
            return _assets.Compressor.CompressContent(content);
        }

        private void ApplyModel(string content)
        {
            if (Model != null)
            {
                if (_modelProperties == null)
                {
                    CacheModelProperties();
                }

                //get all words starting with @, ignore case
               // var matches = Regex.Matches(content, @"(\b@)\w+\b", RegexOptions.IgnoreCase);
                //Regex regex = new Regex(@"(\b@)\w+\b", RegexOptions.IgnoreCase);

                StringBuilder sbcontent = new StringBuilder(content);
                foreach (KeyValuePair<string, string> property in _modelProperties)
                {
                    var s = "@" + property.Key;
                    sbcontent.Replace("@" + property.Key, property.Value);
                }
            }
        }

        private void CacheModelProperties()
        {
            PropertyInfo[] properties = Model.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                _modelProperties.Add(property.Name, (string)property.GetValue(Model, null));
            }
        }
    }
}
