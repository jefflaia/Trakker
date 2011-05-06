using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Bootstrap
{
    public class RegisterAreas : IBootstrapperTask
    {
        public RegisterAreas()
        {

        }

        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}