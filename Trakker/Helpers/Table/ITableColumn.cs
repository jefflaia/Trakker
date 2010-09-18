using System;
using Trakker.Helpers.Table.Controls;
using System.Web.UI;
namespace Trakker.Helpers.Table
{
    public interface ITableColumn
    {
        bool Ignore { get; set; }
        string Name { get; set; }
        void RenderTableData(object value, HtmlTextWriter writer);
        void RenderTableHeader(HtmlTextWriter writer);
        TableColumn SetControl(TableControl control);
        TableColumn SetHeaderText(string text);
    }
}
