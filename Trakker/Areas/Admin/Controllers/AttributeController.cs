using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Controllers;

namespace Trakker.Areas.Admin.Controllers
{
    public class AttributeController : MasterController
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
