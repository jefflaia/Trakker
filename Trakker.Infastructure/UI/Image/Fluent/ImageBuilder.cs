using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using System.Web.UI;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class ImageBuilder : ImageBuilderBase<ImageBase, ImageBuilder>
    {
        public ImageBuilder(ImageBase component, IImageProfile profile, IImageHtmlBuilder htmlBuilder, HtmlTextWriter writer)
            : base(component, profile, htmlBuilder, writer)
        {
        }
    }
}
