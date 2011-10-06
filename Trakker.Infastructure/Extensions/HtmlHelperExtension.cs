using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Trakker.Infastructure.UI;

namespace Trakker.Infastructure.Extensions
{
    public static class HtmlHelperExtension
    {
        private static readonly string Key = typeof(ViewComponentFactory).AssemblyQualifiedName;

        public static ViewComponentFactory Ctm(this HtmlHelper helper)
        {
            //ViewComponentFactory factory = httpContext.Items[Key] as ViewComponentFactory;


            IClientSideObjectWriterFactory clientSideObjectWriterFactory = new ClientSideObjectWriterFactory();
            ViewComponentFactory factory = new ViewComponentFactory(helper, clientSideObjectWriterFactory);

            return factory;
        }
    }
}
