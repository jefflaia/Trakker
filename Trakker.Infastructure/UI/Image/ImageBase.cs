using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ImageBase : ViewComponentBase, IImage 
    {

        public ImageBase(IAssetManager assetManager)
            : base(assetManager)
        {
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

    }
}
