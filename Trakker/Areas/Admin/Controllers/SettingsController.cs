using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Areas.Admin.Models;
using Trakker.Controllers;
using Trakker.Data.Services;

namespace Trakker.Areas.Admin.Controllers
{
    public partial class SettingsController : MasterController
    {
        protected ISystemService _systemService;

        public SettingsController(ITicketService ticketService, IUserService userService, IProjectService projectService, ISystemService systemService)
            : base(projectService, ticketService, userService)
        {
            _systemService = systemService;
        }

        public virtual ActionResult BrowseColorPalettes()
        {
            return View(new BrowseColorPalettes()
            {
                ColorPalettes = _systemService.GetAllColorPalettes()
            });
        }
    }
}
