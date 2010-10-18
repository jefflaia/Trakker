using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.Helpers;

namespace Trakker.Controllers
{

    public class NavController : Controller
    {
        #region Widget
        public PartialViewResult ticketListPagination(int totalItemCount, int pageIndex, int pageSize)
        {
            return PartialView(new Pagination(totalItemCount, pageIndex, pageSize));
        }
        #endregion
    }
}
