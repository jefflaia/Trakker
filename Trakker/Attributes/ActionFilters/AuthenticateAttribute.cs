using System.Reflection;
using System.Web.Routing;
using System.Web.Mvc;
using Trakker.Services;
using System.Web;
using System.Web.Security;
using Trakker.IoC;


namespace Trakker.Attributes
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {

        public AuthenticateAttribute()
        {
            
        }


        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            IUserService userSerivce = WindsorContainerProvider.GetInstance().Resolve<IUserService>();

            if (userSerivce.CurrentUser != null) return;

            HttpContext ctx = HttpContext.Current;

            //TODO:: not the best.. would like to use lambda expressions for the login url. 
            //if this changes i dont want to remember to change it
            ctx.Response.Redirect(FormsAuthentication.LoginUrl);
                
            base.OnActionExecuting(actionContext);
        }
    }
}

