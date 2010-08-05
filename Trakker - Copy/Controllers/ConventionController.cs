using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Trakker.Helpers;
using Trakker.Core;
using Trakker.ViewData.SharedData;

namespace Trakker.Controllers
{
    public abstract class ConventionController : BaseMasterController<MasterViewData>
    {
        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName);
        }

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   IDictionary<string, object> dictionary)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(dictionary));
        }

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   object values)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(values));
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.ViewData["SelectedItem"] = this.GetType().Name;
        }


     
    }
}