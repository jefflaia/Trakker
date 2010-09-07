using System;
namespace Trakker.Helpers.Table
{
    public interface IHtmlTableRow
    {
        void AddCell(IHtmlTableCell cell);
        void Render();
    }
}
