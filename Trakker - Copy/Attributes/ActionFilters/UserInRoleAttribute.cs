using System.Reflection;
using System.Web.Routing;
using System.Web.Mvc;

namespace Trakker.Attributes
{
    public class UserInRoleAttribute : ActionFilterAttribute
    {
        protected readonly string roleName;

        public UserInRoleAttribute(string roleName)
        {
            this.roleName = roleName;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            if (actionContext.HttpContext.User.IsInRole(roleName)) return;

            //use reflection until they expose this method
            MethodInfo methodInfo = actionContext.Controller.GetType()
                .GetMethod("RedirectToAction",
                    BindingFlags.ExactBinding |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance, null,
                    new[]{
                        typeof (RouteValueDictionary)
                    }, null);

            methodInfo.Invoke(actionContext.Controller, new object[]{
                    new RouteValueDictionary(new
                    {
                        controller = "User",
                        action = "Login",
                        redirect = actionContext.HttpContext.Request.Url.AbsolutePath
                    })
                });
        }
    }
}

