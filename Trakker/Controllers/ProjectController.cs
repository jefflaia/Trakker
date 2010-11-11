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

        public ActionResult AllProjects()
        {
            return View(new AllProjectsViewData()
            {
                Projects = _projectService.GetAllProjects()
            });
        }

        public ActionResult CreateProject()
        {
            return View(new CreateProjectViewData()
            {
                Users = _userService.GetAllUsers()
            });
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectViewData viewData)
        {

            if (_projectService.GetProjectByKeyName(viewData.KeyName) != null)
            {
                ModelState.AddModelError("KeyName", "A project with this key already exists. Please choose another.");
            }

            if (_projectService.GetProjectByName(viewData.Name) != null)
            {
                ModelState.AddModelError("Name", "A project with this name already exists. Please choose another.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateProjectViewData, Project>();
                Project project = Mapper.Map(viewData, new Project());

                project.Created = DateTime.Now;
                _projectService.Save(project);
                UnitOfWork.Commit();
            }
            

            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
        }

        [HttpGet]
        public ActionResult EditProject(string projectKeyName)
        {
            Project project = _projectService.GetProjectByKeyName(projectKeyName);
           
            Mapper.CreateMap<Project, EditProjectViewData>();
            EditProjectViewData viewData = Mapper.Map(project, new EditProjectViewData());

            viewData.Users = _userService.GetAllUsers();

            //if(project == null); //TODO:: redirect to page not-found
            return View(viewData);
        }

        [HttpPost]

        public ActionResult EditProject(string projectKeyName, [Bind(Exclude = "KeyName")]EditProjectViewData viewData)
        {
            Project project = _projectService.GetProjectByKeyName(projectKeyName);

            if (project == null)
            {
                throw new NotImplementedException("need to redirect to a general error page");
            }

            //check if the project name already exists
            Project projectSameName = _projectService.GetProjectByName(viewData.Name);
            if (projectSameName != null)
            {
                if (projectSameName.ProjectId != project.ProjectId)
                {
                    ModelState.AddModelError("Name", "A project with this name already exists. Please choose another.");
                }
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<EditProjectViewData, Project>();
                project = Mapper.Map(viewData, project);

                _projectService.Save(project);
                UnitOfWork.Commit();

                return RedirectToAction<ProjectController>(x => x.ProjectSummary(project.KeyName));
            }

            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
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
