using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.ViewData.ProjectData;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Attributes;
using AutoMapper;

namespace Trakker.Controllers
{
    [Authenticate]
    public class ProjectController : MasterController
    {

        public ProjectController(IProjectService projectService, IUserService userService, ITicketService ticketService)
            : base(projectService, ticketService, userService)
        {
        }

        #region Project
        public ActionResult ProjectSummary(string keyName)
        {
            CurrentProject = _projectService.GetProjectByKeyName(keyName);

            return View(new ProjectSummaryViewData()
            {
                Project = CurrentProject,
                NewestTickets = _ticketService.GetNewestTicketsWithProjectId(CurrentProject.ProjectId, 5),
                Lead = _userService.GetUserWithId(CurrentProject.Lead)
            });
        }

        #endregion


        #region Component
        public ActionResult ComponentSummary(string keyName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
