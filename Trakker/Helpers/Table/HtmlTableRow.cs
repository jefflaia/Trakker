using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.Web.UI;

namespace Trakker.Helpers.Table
{
    public class HtmlTableRow : IHtmlTableRow
    {
        const string TAG = "tr";

        private ICollection<IHtmlTableCell> Cells { get; set; }
        private HtmlTextWriter _writer;

        public HtmlTableRow(HtmlTextWriter writer)
        {
            _writer = writer;
            Cells = new Collection<IHtmlTableCell>();
        }

        public void AddCell(IHtmlTableCell cell)
        {
            Cells.Add(cell);
        }

        public void Render()
        {
            _writer.RenderBeginTag(TAG);
          
            foreach (HtmlTableCell cell in Cells)
            {
                cell.Render();
            }

            _writer.RenderEndTag();
        }
    }
}