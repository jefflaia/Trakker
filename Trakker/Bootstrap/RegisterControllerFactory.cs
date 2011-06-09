using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Bootstrap
{
    public class RegisterControllerFactory : IBootstrapperTask
    {

        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }
    }
}