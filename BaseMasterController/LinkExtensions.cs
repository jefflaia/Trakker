
namespace Trakker.Core
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    public static class LinkExtensions {


        /// <summary>
        /// Creates an anchor tag based on the passed in controller type and method
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")]
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText) where TController : Controller {
            return ActionLink<TController>(helper, action, linkText, null);
        }

        /// <summary>
        /// Creates an anchor tag based on the passed in controller type and method
        /// </summary>
        /// <typeparam name="TController">The Controller Type</typeparam>
        /// <param name="action">The Method to route to</param>
        /// <param name="linkText">The linked text to appear on the page</param>
        /// <returns>System.String</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")]
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText, object htmlAttributes) where TController : Controller {
            RouteValueDictionary routingValues = action.GetRouteValuesFromExpression<TController>();

            return helper.RouteLink(linkText, routingValues, new RouteValueDictionary(htmlAttributes));
        }
    }
}
