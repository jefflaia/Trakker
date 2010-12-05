using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.Data.Services;
using Trakker.Data;
using Trakker.Attributes;
using AutoMapper;
using Trakker.Models;

namespace Trakker.Controllers
{
    [Authenticate]
    public partial class ProjectController : MasterController
    {

        public ProjectController(IProjectService projectService, IUserService userService, ITicketService ticketService)
            : base(projectService, ticketService, userService)
        {
        }
        
        #region Project
        public virtual ActionResult ProjectSummary(string keyName)
        {
            CurrentProject = _projectService.GetProjectByKeyName(keyName);

            return View(new ProjectSummaryModel()
            {
                Project = CurrentProject,
                NewestTickets = _ticketService.GetNewestTicketsWithProjectId(CurrentProject.Id, 5),
                Lead = _userService.GetUserWithId(CurrentProject.Lead)
            });
        }

        #endregion


        #region Component
        public virtual ActionResult ComponentSummary(string keyName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
