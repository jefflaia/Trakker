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
using Trakker.Data.Repositories;

namespace Trakker.Areas.Admin.Controllers
{
    [Authenticate]
    public partial class ManagementController : MasterController
    {
        public ManagementController(ITicketService ticketService, IUserService userService, IProjectService projectService, IUserRepository userRepo)
            : base(projectService, ticketService, userService, userRepo)
        {
        }

        public virtual ActionResult Index()
        {
            return View(new ManagementIndexModel());
        }

        #region User

        public virtual ActionResult BrowseUsers()
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

        public virtual ActionResult ViewUser(int userId)
        {
            return View(new ViewUserModel()
            {
                User = _userRepo.GetUserById(userId)
            });
        }

        public virtual ActionResult CreateUser()
        {
            return View(new CreateUserModel()
            {
                Roles = _userService.GetAllRoles()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateUser(CreateUserModel viewModel)
        {
            User existingUser = _userRepo.GetUserByEmail(viewModel.Email);
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
                return RedirectToAction(MVC.Admin.Management.BrowseUsers());
            }

            viewModel.Roles = _userService.GetAllRoles();

            return View(viewModel);
        }

        public virtual ActionResult EditUser(int userId)
        {
            User user = _userRepo.GetUserById(userId);
            if (user == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<User, EditUserModel>();
            EditUserModel viewModel = Mapper.Map(user, new EditUserModel() {
                Roles = _userService.GetAllRoles()
            });
            
            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult EditUser(int userId, EditUserModel viewModel)
        {
            User user = _userRepo.GetUserById(userId);

            if (user == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<EditUserModel, User>();
            Mapper.Map(viewModel, user);

            if (ModelState.IsValid)
            {
                _userService.Save(user);
                UnitOfWork.Commit();
                return RedirectToRoute(MVC.Admin.Management.ViewUser(userId));
            }

            viewModel.Roles = _userService.GetAllRoles();
            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult EditUserPassword(int userId)
        {
            return View(new EditUserPasswordModel() { 
                User = _userRepo.GetUserById(userId)
            });
        }

        [HttpPost]
        public virtual ActionResult EditUserPassword(int userId, EditUserPasswordModel viewModel)
        {
            User user = _userRepo.GetUserById(userId);

            if (user == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<EditUserPasswordModel, User>();
            Mapper.Map(viewModel, user);

            if (ModelState.IsValid)
            {
                user.Password = Auth.HashPassword(user.Password, user.Salt);
                _userService.Save(user);
                UnitOfWork.Commit();
                return RedirectToAction(MVC.Admin.Management.ViewUser(userId));
            }

            viewModel.User = _userRepo.GetUserById(userId);
            return View(viewModel);
        }

        #endregion

        #region Project
        public virtual ActionResult BrowseProjects()
        {
            return View(new BrowseProjectsModel()
            {
                Projects = _projectService.GetAllProjects(),
                Users = _userService.GetAllUsers().ToDictionary(m => m.Id)
            });
        }

        public virtual ActionResult ViewProject(string keyName)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            return View(new ViewProjectModel()
                {
                    Project = project,
                    User = _userRepo.GetUserById(project.Lead)
                });
        }

        public virtual ActionResult CreateProject()
        {
            return View(new CreateProjectModel()
            {
                Users = _userService.GetAllUsers()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateProject(CreateProjectModel viewModel)
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
                return RedirectToAction(MVC.Admin.Management.ViewProject(viewModel.KeyName));
            }


            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult EditProject(string keyName)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            if (project == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<Project, EditProjectModel>();
            EditProjectModel viewModel = Mapper.Map(project, new EditProjectModel());

            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult EditProject(string keyName, [Bind(Exclude = "KeyName")]EditProjectModel viewModel)
        {
            Project project = _projectService.GetProjectByKeyName(keyName);

            if (project == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
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
                return RedirectToRoute(MVC.Admin.Management.ViewProject(project.KeyName));
            }

            viewModel.Users = _userService.GetAllUsers();

            return View(viewModel);
        }
        #endregion
    }
}
