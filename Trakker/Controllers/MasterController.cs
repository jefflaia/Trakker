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

        private ProjectService _projectService;
        private TicketService _ticketService;

        public MasterController()
        {
            _projectService = new ProjectService();
            _ticketService = new TicketService();
        }

        protected override MasterViewData GetMasterViewData()
        {
            MasterViewData viewData = new MasterViewData()
                {
                    Projects =  _projectService.GetAllProjects(),
                    HasCurrentProject = true,
                    CurrentProject = _projectService.GetProjectByProjectId(ProjectService.SelectedProjectId),
                    CurrentUser = AuthorizationService.CurrentUser,
                    IsUserLoggedIn = AuthorizationService.IsUserLoggedIn(), 
                    Tickets = _ticketService.GetNewestTicketsWithProjectId(ProjectService.SelectedProjectId, 5),
                    NumTicketsAssignedToCurrentUser = 0

                };

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketService.CountTicketsWithAssignedTo(AuthorizationService.CurrentUser.UserId);
            }

            return viewData;
        }
    }


}
