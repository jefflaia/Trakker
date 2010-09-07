using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.UI;

namespace Trakker.Helpers.Table
{
    public class HtmlTableCell : IHtmlTableCell
    {
        const string DEFAULT_TAG = "td";
        private HtmlTextWriter _writer;

        public HtmlTableCell(HtmlTextWriter writer)
        {
            _writer = writer;
            Tag = DEFAULT_TAG;
        }

        public HtmlTableCell(HtmlTextWriter writer, string tag)
        {
            _writer = writer;
            Tag = tag;
        }
        
        public string InnerText{ get; set; }
        public string Tag { get; set; }


        public void Render()
        {
            _writer.RenderBeginTag(Tag);
            _writer.Write(InnerText);
            _writer.RenderEndTag();
        }
    }
}