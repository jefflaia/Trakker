using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trakker.ViewData.ProjectData;
using Trakker.Services;
using Trakker.Data;
using Trakker.Attributes;

namespace Trakker.Controllers
{
    [Authenticate]
    public class ProjectController : MasterController
    {
        protected readonly IProjectService _projectService;
        protected readonly IUserService _userService;

        public ProjectController(IProjectService projectService, IUserService userService, ITicketService ticketService)
            : base(projectService, ticketService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        public ActionResult ProjectSummary(string keyName)
        {

            Project project = _projectService.GetProjectByKeyName(keyName);

            ProjectService.SelectedProjectId = project.ProjectId;   
               
            return View(new ProjectSummaryViewData());
        }

        public ActionResult AllProjects()
        {
            return View(new AllProjectsViewData()
            {
                Projects = _projectService.GetAllProjects()
            });
        }

        public ActionResult ComponentSummary(string keyName)
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateProject()
        {

            CreateEditProjectViewData viewData = new CreateEditProjectViewData()
            {
                Project = new Project(),
                Users = _userService.GetAllUsers()
            };

            return View(viewData);
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            //_projectService.GetProjectByKeyName(project.KeyName);
            //_projectService.GetProjectByName(project.Name);
            //get the project by keyname and name see if they are unique. if not post error

            try
            {
                _projectService.Save(project);
                return RedirectToAction<ProjectController>(x => x.ProjectSummary(project.KeyName));
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
            }

            CreateEditProjectViewData viewData = new CreateEditProjectViewData()
            {
                Project = project,
                Users = _userService.GetAllUsers()
            };

            return View(viewData);
        }

        [HttpGet]
        public ActionResult EditProject(string projectKeyName)
        {
            Project project = _projectService.GetProjectByKeyName(projectKeyName);

            //if(project == null); //TODO:: redirect to page not-found

            CreateEditProjectViewData viewData = new CreateEditProjectViewData()
            {
                Project = project,
                Users = _userService.GetAllUsers()
            };

            return View(viewData);
        }

        [HttpPost]
        public ActionResult EditProject(string projectKeyName, Project project)
        {
            Project p = _projectService.GetProjectByKeyName(projectKeyName);

            //if (p == null) ; //TODO:: redirect to page not-found


            try
            {
                project.ProjectId = p.ProjectId;
                project.Created = p.Created;
                _projectService.Save(project);

                return RedirectToAction<ProjectController>(x => x.ProjectSummary(projectKeyName));
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
            }

            CreateEditProjectViewData viewData = new CreateEditProjectViewData()
            {
                Project = project,
                Users = _userService.GetAllUsers()
            };

            return View(viewData);
        }
    }
}
