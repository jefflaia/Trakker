using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;

namespace Trakker.Infastructure.UI
{
    public class ImageBuilder : ImageBuilderBase<ImageBase, ImageBuilder>
    {
        public ImageBuilder(ImageBase component, IImageProfile profile)
            : base(component, profile)
        {
        }
    }
}
