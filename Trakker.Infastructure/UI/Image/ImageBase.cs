using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ImageBase : ViewComponentBase, IImage 
    {
        public ImageBase(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory) :
            base(viewContext, clientSideObjectWriterFactory)
        {
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
    }
}
