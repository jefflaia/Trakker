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

        public ActionResult CreateProject()
        {
            return View(new CreateEditProjectViewData()
            {
                Users = _userService.GetAllUsers()
            });
        }

        [HttpPost]
        public ActionResult CreateProject(CreateEditProjectViewData viewData)
        {
            //TODO:: add this to check if the keyname already exists
            //_projectService.GetProjectByName(project.Name);

            if (false)
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<CreateEditProjectViewData, Project>();
                    Project project = Mapper.Map(viewData, new Project());

                    project.Created = DateTime.Now;
                    _projectService.Save(project);
                    UnitOfWork.Commit();
                }
            }
            else
            {
                ModelState.AddModelError("KeyName", "A project with this key already exists. Please choose another.");
            }

            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
        }

        [HttpGet]
        public ActionResult EditProject(string projectKeyName)
        {
            Project project = _projectService.GetProjectByKeyName(projectKeyName);

            //if(project == null); //TODO:: redirect to page not-found
            return View(new CreateEditProjectViewData()
            {
                Users = _userService.GetAllUsers()
            });
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
                //Project = project,
                Users = _userService.GetAllUsers()
            };

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
