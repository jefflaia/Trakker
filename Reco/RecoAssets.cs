
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reco.JavaScript;
using System.Web;
using Reco.Assets;

namespace Reco
{
    public class RecoAssets
    {
        //singleton instantiation to avoid using lock
        private static IStyleSheetAssets _styleSheetRegistrar = new StyleSheetAssets();
        private static IJavaScriptRegistrar _jsRegistrar = new JavaScriptRegistrar();

        public static IStyleSheetAssets StyleSheet()
        {
            return _styleSheetRegistrar;
        }

        public static IJavaScriptRegistrar JavaScript()
        {
            return _jsRegistrar;
        }

        /*
        public static string CurrentVersion()
        {
            try
            {
                return ConfigurationManager.AppSettings["version"];
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }*/

    }
}
