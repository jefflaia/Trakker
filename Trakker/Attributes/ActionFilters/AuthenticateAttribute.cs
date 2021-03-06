﻿using System.Reflection;
using System.Web.Routing;
using System.Web.Mvc;
using Trakker.Data.Services;
using System.Web;
using System.Web.Security;
using Trakker.Core.IoC;
using Trakker.Data;


namespace Trakker.Attributes
{
    public class AuthenticateAttribute : BaseAuthorizationActionFilterAttribute
    {

        public AuthenticateAttribute() : base()
        {
            
        }


        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (Auth.CurrentUser != null) return;

            HttpContext ctx = HttpContext.Current;

            //TODO:: not the best.. would like to use lambda expressions for the login url. 
            //if this changes i dont want to remember to change it
            ctx.Response.Redirect(FormsAuthentication.LoginUrl);
                
            base.OnActionExecuting(actionContext);
        }
    }
}

