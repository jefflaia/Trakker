using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ViewComponentFactory
    {

        public ViewComponentFactory(HtmlHelper helper, IClientSideObjectWriterFactory clientSideObjectWriterFactory)
        {
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;
            HtmlHelper = helper;
        }

        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory { get; set; }
        public HtmlHelper HtmlHelper { get; set; }


        /*

        public virtual ImageBuilderBase Image(File file)
        {
            return new ImageBuilderBase<ImageBase, ImageBaseHtmlBuilder<
        }
         * 
         */
    }
}
