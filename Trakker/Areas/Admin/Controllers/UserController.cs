using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Controllers;
using Trakker.Data.Services;
using Trakker.Areas.Admin.ViewData;

namespace Trakker.Areas.Admin.Controllers
{
    public class UserController : MasterController
    {
        public UserController(IUserService userService, ITicketService ticketService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }

        public ActionResult Index()
        {
            return View(new IndexViewData());
        }

    }
}
