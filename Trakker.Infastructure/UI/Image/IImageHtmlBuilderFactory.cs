using System;
namespace Trakker.Infastructure.UI
{
    public interface IImageHtmlBuilderFactory
    {
        IImageBaseHtmlBuilder Create(ImageBase element);
    }
}
