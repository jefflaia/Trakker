using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.Helpers;

namespace Trakker.Controllers
{

    public partial class NavController : Controller
    {
        public virtual ActionResult Pagination(int count, int page, int pageSize)
        {
            return PartialView(new Pagination(count, page, pageSize));
        }
    }
}
