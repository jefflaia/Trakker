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

namespace Trakker.Controllers
{


    //[CompressFilter]
    public class ResourceController : Controller
    {
        
        //[CacheFilter(Duration = 9999999)]
        public virtual StyleSheetResult CSS(string fileName)
        {
            return new StyleSheetResult()
            {
                Content = Reco.StyleSheet().Generate()
            };
        }
    }
}
