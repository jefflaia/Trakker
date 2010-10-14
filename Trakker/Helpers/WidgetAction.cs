using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

using System.Linq.Expressions;


namespace Trakker.Helpers
{
    public sealed class WidgetAction
    {
        public RouteValueDictionary RouteValues { get; set; }

        public WidgetAction(object routeValues)
        {
            RouteValues = new RouteValueDictionary(routeValues);

           
        }

        public WidgetAction(string actionName, string controllerName, object routeValues)
        {
            RouteValueDictionary rvd = null;
            if (routeValues != null)
            {
                rvd = new RouteValueDictionary(routeValues);
            }
            else
            {
                rvd = new RouteValueDictionary();
            }

            if (!string.IsNullOrEmpty(actionName))
            {
                rvd["action"] = actionName;
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                rvd["controller"] = controllerName;
            }

            RouteValues = rvd;
         
        }

        public WidgetAction(string actionName, string controllerName)
        {
            RouteValueDictionary rvd = new RouteValueDictionary();
           
            if (!string.IsNullOrEmpty(actionName))
            {
                rvd["action"] = actionName;
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                rvd["controller"] = controllerName;
            }

            RouteValues = rvd;

        }

        public void Render(ControllerContext context)
        {
            RouteData rd = new RouteData(context.RouteData.Route, context.RouteData.RouteHandler);
            foreach (var pair in RouteValues)
                rd.Values.Add(pair.Key, pair.Value);
            IHttpHandler handler = new MvcHandler(new RequestContext(context.HttpContext, rd));
            handler.ProcessRequest(System.Web.HttpContext.Current);
        }
    }


    public static class WidgetActionExtensions{
        public static void Instance<TController>(this WidgetAction widgetAction, Expression<Action<TController>> action) where TController : Controller
        {
            //widgetAction.RouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action);
        }
    }
}
