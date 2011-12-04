using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using Trakker.Infastructure.Uploading;
using System.Web.Mvc;
using System.Web;
using ResourceCompiler;

namespace Trakker.Infastructure.UI
{
    public static class CtmHtmlExtension
    {
        public static ViewComponentFactory Ctm(this HtmlHelper helper)
        {
            return new ViewComponentFactory(helper, new ClientSideObjectWriterFactory(), new RecoAssetAdapter(RecoAssets.StyleSheet(), RecoAssets.JavaScript()));
        }

        public static ViewComponentFactory<TModel> Ctm<TModel>(this HtmlHelper<TModel> helper)
        {
            return new ViewComponentFactory<TModel>(helper, new ClientSideObjectWriterFactory(), new RecoAssetAdapter(RecoAssets.StyleSheet(), RecoAssets.JavaScript()));
        }
    }
}
