using System;
namespace Trakker.Infastructure.UI
{
    public interface IImageHtmlBuilderFactory<T> where T : struct
    {
        IImageBaseHtmlBuilder Create(ImageBase element);
    }
}
