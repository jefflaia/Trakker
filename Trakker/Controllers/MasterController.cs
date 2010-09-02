using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.Data;
using Trakker.ViewData.SharedData;
using Trakker.Core;
using Trakker.Services;

namespace Trakker.Controllers
{

    public abstract class MasterController : ConventionController
    {

        protected IProjectService _projectService;
        protected ITicketService _ticketService;
        protected IUserService _userService;

        public MasterController(IProjectService projectService, ITicketService ticketService, IUserService userSerivice)
        {
            _projectService = projectService;
            _ticketService = ticketService;
            _userService = userSerivice;
        }

        protected override MasterViewData GetMasterViewData()
        {
            MasterViewData viewData = new MasterViewData()
            {
                Projects =  _projectService.GetAllProjects(),
                HasCurrentProject = true,
                CurrentProject = _projectService.GetProjectByProjectId(ProjectService.SelectedProjectId),
                CurrentUser = _userService.CurrentUser,
                IsUserLoggedIn = _userService.IsUserLoggedIn(), 
                Tickets = _ticketService.GetNewestTicketsWithProjectId(ProjectService.SelectedProjectId, 5),
                NumTicketsAssignedToCurrentUser = 0
            };

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketService.CountTicketsWithAssignedTo(_userService.CurrentUser.UserId);
            }

            return viewData;
        }
    }


}
