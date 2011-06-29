namespace Trakker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Security.Principal;
    using System.Configuration;
    using System.ComponentModel;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Bootstrapper.Run();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        protected void Application_BeginRequest()
        {
           //may want boostrapping to run here
        }

        protected void Application_EndRequest()
        {
            //may want bootstrapping to run here
        }

    }
}