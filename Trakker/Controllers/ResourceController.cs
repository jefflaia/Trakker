using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.UI.MobileControls;
using ResourceCompiler;
using Trakker.Filters;
using Trakker.Models;
using Trakker.Data;
using Trakker.Data.Services;

namespace Trakker.Controllers
{
    [CompressFilter]
    public partial class ResourceController : Controller
    {
        protected ISystemService _systemService;

        public ResourceController(ISystemService systemService)
        {
            _systemService = systemService;
        }
        
        //[CacheFilter(Duration = 9999999)]
        public virtual StyleSheetResult CSS(string fileName)
        {
            //make the  result types do the mapping
            //have the view returns take the model like other view results
            //no need to know about the renderer stuff
            //how could i handle groups?

            StyleSheetRenderer renderer = new StyleSheetRenderer(RecoAssets.StyleSheet());

            var property = _systemService.GetPropertyByName<int>("colorPaletteId");

            renderer.Model = _systemService.GetColorPaletteById(property.Value);
            
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
