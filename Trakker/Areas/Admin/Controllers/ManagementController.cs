using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Areas.Admin.Models.Management;

namespace Trakker.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
        //
        // GET: /Admin/Management/

        public ActionResult Index()
        {
            return View(new IndexModel());
        }

    }
}
