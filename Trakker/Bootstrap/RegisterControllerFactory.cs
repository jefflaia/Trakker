using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Bootstrap
{
    public class RegisterControllerFactory : IBootstrapperTask
    {
        private readonly IControllerFactory _factory;

        public RegisterControllerFactory(IControllerFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(_factory);
        }
    }
}