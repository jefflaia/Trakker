using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Areas.Admin.Models.Management;
using Trakker.Controllers;
using Trakker.Data.Services;
using Trakker.Attributes;
using AutoMapper;
using Trakker.Data;

namespace Trakker.Areas.Admin.Controllers
{
    public class ManagementController : MasterController
    {
        public ManagementController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }

        public ActionResult Index()
        {
            return View(new IndexModel());
        }

        #region User

        [Authenticate]
        public ActionResult UserList()
        {
            var paginatedUsers = _userService.GetAllUsersPaginated(1, 10);

            return View(new UserListModel()
            {
                Users = paginatedUsers.Items,
                TotalUsers = paginatedUsers.TotalItems,
                PageSize = 10,
                CurrentPage = 1,
                Roles = _userService.GetAllRoles().ToDictionary(d => d.RoleId)
            });
        }

        [Authenticate]
        public ActionResult CreateUser()
        {
            return View(new CreateEditUserModel()
            {
                Roles = _userService.GetAllRoles()
            });
        }

        [HttpPost]
        [Authenticate]
        public ActionResult CreateUser(CreateEditUserModel viewData)
        {
            User existingUser = _userService.GetUserWithEmail(viewData.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditUserModel, User>();
                User user = Mapper.Map(viewData, new User());

                _userService.Save(user);
                UnitOfWork.Commit();
            }

            viewData.Roles = _userService.GetAllRoles();

            return View(viewData);
        }

        [Authenticate]
        public ActionResult EditUser(int userId)
        {
            //if (userId == 0) ; //TODO:: redirect

            User user = _userService.GetUserWithId(userId);


            return View(new CreateEditUserModel()
            {
                Email = user.Email,
                Roles = _userService.GetAllRoles(),
                RoleId = user.RoleId
            });
        }

        [HttpPost]
        [Authenticate]
        public ActionResult EditUser(int userId, CreateEditUserModel viewData)
        {
            //if (userId == 0) ; //TODO:: redirect

            Mapper.CreateMap<CreateEditUserModel, User>();
            User user = Mapper.Map(viewData, new User());



            User u = _userService.GetUserWithId(userId);
            //if(u == null); //TODO:: redirect

            try
            {

                _userService.Save(user);
            }
            catch (Exception e)
            {
                //TODO:: rollback
            }


            viewData.Roles = _userService.GetAllRoles();

            return View(viewData);
        }
        #endregion

        #region Project
        public ActionResult AllProjects()
        {
            return View(new AllProjectsModel()
            {
                Projects = _projectService.GetAllProjects()
            });
        }

        public ActionResult CreateProject()
        {
            return View(new CreateProjectModel()
            {
                Users = _userService.GetAllUsers()
            });
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectModel viewData)
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
                Mapper.CreateMap<CreateProjectModel, Project>();
                Project project = Mapper.Map(viewData, new Project());

                project.Created = DateTime.Now;
                _projectService.Save(project);
                UnitOfWork.Commit();
            }


            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
        }

        [HttpGet]
        public ActionResult EditProject(string keyName)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            if (project == null) throw new NotImplementedException("project not found");

            Mapper.CreateMap<Project, EditProjectModel>();
            EditProjectModel viewData = Mapper.Map(project, new EditProjectModel());

            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
        }

        [HttpPost]
        public ActionResult EditProject(string keyName, [Bind(Exclude = "KeyName")]EditProjectModel viewData)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

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
                Mapper.CreateMap<EditProjectModel, Project>();
                project = Mapper.Map(viewData, project);

                _projectService.Save(project);
                UnitOfWork.Commit();

                return RedirectToRoute("ProjectSummary", new { keyName = project.KeyName });
            }

            viewData.Users = _userService.GetAllUsers();

            return View(viewData);
        }
        #endregion
    }
}
