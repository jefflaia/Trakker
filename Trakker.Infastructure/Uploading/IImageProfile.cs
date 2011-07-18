using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Uploading
{
    public class ImageProperties
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Prefix { get; set; }
    }
    

    public interface IImageProfile
    {
        string Identifier { get; }
        ImageProperties Icon{ get; }
        ImageProperties Thumbnail { get; }
        ImageProperties Large { get; }
        bool KeepOriginal { get; }
    }
}
