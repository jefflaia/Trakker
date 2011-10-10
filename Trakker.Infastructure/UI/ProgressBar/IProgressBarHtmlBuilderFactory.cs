using System;
namespace Trakker.Infastructure.UI
{
    public interface IProgressBarHtmlBuilderFactory
    {
        IProgressBarBaseHtmlBuilder Create(ProgressBarBase element);
    }
}
