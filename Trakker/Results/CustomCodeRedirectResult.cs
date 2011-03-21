using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trakker.Controllers
{
    public class CustomCodeRedirectResult : ActionResult
    {
        public string Url { get; set; }
        public int StatusCode { get; set; }

        public CustomCodeRedirectResult(RequestContext context, ActionResult result, int statusCode)
        {
            UrlHelper urlHelper = new UrlHelper(context);
            this.Url = urlHelper.Action(result);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.HttpContext.Response.StatusCode = StatusCode;
            context.HttpContext.Response.RedirectLocation = Url;
            context.HttpContext.Response.End();
        }
    }
}