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
using Trakker.Models.Project;

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
        public virtual ActionResult OverviewTab(int projectId)
        {
            CurrentProject = _projectRepo.GetProjectById(projectId);

            return View(new ProjectOverviewTabModel()
            {
                Project = CurrentProject,
                NewestTickets = _ticketRepo.GetNewestTicketsByProject(CurrentProject, 0, 5).Items,
                Lead = _userRepo.GetUserById(CurrentProject.Lead)
            });
        }

        public virtual ActionResult RoadMapTab(int projectId)
        {
            Project project = _projectRepo.GetProjectById(projectId);
            IList<ProjectVersion> versions = _projectRepo.GetVersionsByProject(project);

            foreach (var version in versions)
            {
                version.FixedTickets = _ticketRepo.GetFixedTicketsByVersion(version);
            }

            return View(new ProjectRoadMapTabModel()
            {
                Versions = versions,
                Project = project
            });
        }

        public virtual ActionResult ReleaseNotes(int projectId, int versionId)
        {
            return View(new ReleaseNotesModel()
            {
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
