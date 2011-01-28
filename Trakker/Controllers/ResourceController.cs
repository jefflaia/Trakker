using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.UI.MobileControls;
using Telerik.Web.Mvc;
using ResourceCompiler;
using Trakker.Filters;
using Trakker.Models;

namespace Trakker.Controllers
{
    [CompressFilter]
    public class ResourceController : Controller
    {
        
        //[CacheFilter(Duration = 9999999)]
        public virtual StyleSheetResult CSS(string fileName)
        {
            StyleSheetRenderer renderer = new StyleSheetRenderer(RecoAssets.StyleSheet());
            renderer.Model = new ThemeModel()
            {
                NavBackgroundColor = "Red",
                SubNavBackgroundColor = "Pink",
                HighlightColor = "lightpink",
                NavTextColor = "white",
                SubNavTextColor = "white",
                LinkColor = "red",
                LinkActiveColor = "red"
            };

            return new StyleSheetResult()
            {
                Content = renderer.Generate()
            };
        }

        public virtual JavaScriptResult JS(string fileName)
        {
            return new JavaScriptResult()
            {
                Script = new JavaScriptRenderer(RecoAssets.JavaScript()).Generate()
            };
        }

    }
}
