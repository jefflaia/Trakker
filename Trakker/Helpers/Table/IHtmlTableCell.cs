using System;
namespace Trakker.Helpers.Table
{
    public interface IHtmlTableCell
    {
        string InnerText { get; set; }
        void Render();
        string Tag { get; set; }
    }
}
