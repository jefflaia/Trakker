using System.Reflection;
using System.Web.Routing;
using System.Web.Mvc;
using Trakker.Services;
using System.Web;
using System.Web.Security;
using Trakker.IoC;


namespace Trakker.Attributes
{
    public class AuthenticateAttribute : BaseAuthorizationActionFilterAttribute
    {

        public AuthenticateAttribute() : base()
        {
            
        }


        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (_userService.CurrentUser != null) return;

            HttpContext ctx = HttpContext.Current;

            //TODO:: not the best.. would like to use lambda expressions for the login url. 
            //if this changes i dont want to remember to change it
            ctx.Response.Redirect(FormsAuthentication.LoginUrl);
                
            base.OnActionExecuting(actionContext);
        }
    }
}

