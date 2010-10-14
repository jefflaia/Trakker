using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Services;
using Trakker.ViewData.SharedData;

namespace Trakker.Controllers
{
    
    
    public class SiteController : MasterController
    {
        public SiteController(IProjectService projectService, ITicketService ticketService, IUserService userSerivice) :
            base(projectService, ticketService, userSerivice)
        {
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return View(new MenuViewData()
            {
                Projects = _projectService.GetAllProjects(),
                HasCurrentProject = true,
                CurrentProject = _projectService.GetProjectByProjectId(ProjectService.SelectedProjectId),
                CurrentUser = _userService.CurrentUser,
                IsUserLoggedIn = _userService.IsUserLoggedIn(),
                Tickets = _ticketService.GetNewestTicketsWithProjectId(ProjectService.SelectedProjectId, 5),
                NumTicketsAssignedToCurrentUser = 0
            });
        }
    }
}
