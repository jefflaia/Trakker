using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Uploading
{
    public class ImageAttributes
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Prefix { get; set; }
    }
    

    public interface IImageProfile
    {
        string Identifier { get; }
        ImageAttributes Icon{ get; }
        ImageAttributes Thumbnail { get; }
        ImageAttributes Large { get; }
        bool KeepOriginal { get; }
    }
}
