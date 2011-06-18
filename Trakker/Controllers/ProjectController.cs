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
using Trakker.Data.Repositories;

namespace Trakker.Controllers
{
    [Authenticate]
    public partial class ProjectController : MasterController
    {

        public ProjectController(ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
            : base(ticketService, userRepo, projectRepo, ticketRepo)
        {
        }
        
        #region Project
        public virtual ActionResult ProjectSummary(string keyName)
        {
            CurrentProject = _projectRepo.GetProjectByKey(keyName);

            return View(new ProjectSummaryModel()
            {
                Project = CurrentProject,
                NewestTickets = _ticketRepo.GetNewestTicketsByProject(CurrentProject, 0, 5).Items,
                Lead = _userRepo.GetUserById(CurrentProject.Lead)
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
