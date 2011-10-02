using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ImageBase : ViewComponentBase, IImage 
    {

        protected IImageHtmlBuilderFactory _renderFactory;

        public ImageBase(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IImageHtmlBuilderFactory renderFactory) :
            base(viewContext, clientSideObjectWriterFactory)
        {
            _renderFactory = renderFactory;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public IDictionary<string, object> InputHtmlAttributes
        {
            get;
            set;
        }

        protected override void WriteHtml(System.Web.UI.HtmlTextWriter writer)
        {
            var builder = _renderFactory.Create(this);
            IHtmlNode rootTag = builder.Build();

            rootTag.WriteTo(writer);
            base.WriteHtml(writer);
        }
    }
}
