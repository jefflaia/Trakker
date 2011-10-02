using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using Trakker.Infastructure.Uploading;
using System.Web.Mvc;
using System.Web;

namespace Trakker.Infastructure.UI
{
    public static class CtmHtmlExtension
    {
        public static ViewComponentFactory Ctm(this HtmlHelper helper)
        {
            return new ViewComponentFactory(helper, new ClientSideObjectWriterFactory());
        }
    }
}
