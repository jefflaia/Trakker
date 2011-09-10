using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public class ImageHtmlBuilderFactory<T> : IImageHtmlBuilderFactory<T> where T : struct
    {
        public IImageBaseHtmlBuilder Create(ImageBase element)
        {
            return new ImageBaseHtmlBuilder<T>(element);
        }
    }
}
