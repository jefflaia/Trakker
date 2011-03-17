using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Models.Error;

namespace Trakker.Controllers
{
    public partial class ErrorController : Controller
    {
        public virtual ActionResult TicketNotFound()
        {
            return View(new TicketNotFoundModel());
        }

        public virtual ActionResult PageNotFound()
        {
            return View(new PageNotFoundModel());
        }

        public virtual ActionResult InvalidAction()
        {
            return View(new InvalidActionModel());
        }

        [HandleError]
        public virtual ActionResult UnexpectedError()
        {
            return View(new UnexpectedErrorModel());
        }
    }
}
