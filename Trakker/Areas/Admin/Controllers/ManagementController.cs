using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Areas.Admin.Models;
using Trakker.Controllers;
using Trakker.Data.Services;
using Trakker.Attributes;
using AutoMapper;
using Trakker.Data;

namespace Trakker.Areas.Admin.Controllers
{
    [Authenticate]
    public class ManagementController : MasterController
    {
        public ManagementController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }

        public ActionResult Index()
        {
            return View(new ManagementIndexModel());
        }

        #region User

        public ActionResult BrowseUsers()
        {
            var paginatedUsers = _userService.GetAllUsersPaginated(1, 10);

            return View(new BrowseUsersModel()
            {
                Users = paginatedUsers.Items,
                TotalUsers = paginatedUsers.TotalItems,
                PageSize = 10,
                CurrentPage = 1,
                Roles = _userService.GetAllRoles().ToDictionary(d => d.Id)
            });
        }

        public ActionResult CreateUser()
        {
            return View(new CreateUserModel()
            {
                Roles = _userService.GetAllRoles()
            });
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserModel viewModel)
        {
            User existingUser = _userService.GetUserWithEmail(viewModel.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateUserModel, User>();
                User user = Mapper.Map(viewModel, new User());

                _userService.Save(user);
                UnitOfWork.Commit();
            }

            viewModel.Roles = _userService.GetAllRoles();

            return View(viewModel);
        }

        public ActionResult EditUser(int userId)
        {
            //if (userId == 0) ; //TODO:: redirect
            User user = _userService.GetUserWithId(userId);
            if(user == null) throw new NotImplementedException("This should be an error page");

            Mapper.CreateMap<User, EditUserModel>();
            EditUserModel viewModel = Mapper.Map(user, new EditUserModel() {
                Roles = _userService.GetAllRoles()
            });
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(int userId, EditUserModel viewModel)
        {
            User user = _userService.GetUserWithId(userId);

            if (user == null) throw new NotImplementedException("This should be an error page");

            Mapper.CreateMap<EditUserModel, User>();
            Mapper.Map(viewModel, user);

            if (ModelState.IsValid)
            {
                _userService.Save(user);
                UnitOfWork.Commit();
            }

            viewModel.Roles = _userService.GetAllRoles();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditUserPassword(int userId)
        {
            return View(new EditUserPasswordModel() { 
                User = _userService.GetUserWithId(userId)
            });
        }

        [HttpPost]
        public ActionResult EditUserPassword(int userId, EditUserPasswordModel viewModel)
        {
            User user = _userService.GetUserWithId(userId);

            if (user == null) throw new NotImplementedException("This should be an error page");

            Mapper.CreateMap<EditUserPasswordModel, User>();
            Mapper.Map(viewModel, user);

            if (ModelState.IsValid)
            {
                user.Password = Auth.HashPassword(user.Password, user.Salt);
                _userService.Save(user);
                UnitOfWork.Commit();
            }

            viewModel.User = _userService.GetUserWithId(userId);
            return View(viewModel);
        }

        #endregion

        #region Project
        public ActionResult BrowseProjects()
        {
            return View(new BrowseProjectsModel()
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
        public ActionResult CreateProject(CreateProjectModel viewModel)
        {

            if (_projectService.GetProjectByKeyName(viewModel.KeyName) != null)
            {
                ModelState.AddModelError("KeyName", "A project with this key already exists. Please choose another.");
            }

            if (_projectService.GetProjectByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "A project with this name already exists. Please choose another.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateProjectModel, Project>();
                Project project = Mapper.Map(viewModel, new Project());

                project.Created = DateTime.Now;
                _projectService.Save(project);
                UnitOfWork.Commit();
            }


            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditProject(string keyName)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            if (project == null) throw new NotImplementedException("project not found");

            Mapper.CreateMap<Project, EditProjectModel>();
            EditProjectModel viewModel = Mapper.Map(project, new EditProjectModel());

            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditProject(string keyName, [Bind(Exclude = "KeyName")]EditProjectModel viewModel)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            if (project == null)
            {
                throw new NotImplementedException("need to redirect to a general error page");
            }

            //check if the project name already exists
            Project projectSameName = _projectService.GetProjectByName(viewModel.Name);
            if (projectSameName != null)
            {
                if (projectSameName.Id != project.Id)
                {
                    ModelState.AddModelError("Name", "A project with this name already exists. Please choose another.");
                }
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<EditProjectModel, Project>();
                project = Mapper.Map(viewModel, project);

                _projectService.Save(project);
                UnitOfWork.Commit();

                return RedirectToRoute("ProjectSummary", new { keyName = project.KeyName });
            }

            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }
        #endregion
    }
}
