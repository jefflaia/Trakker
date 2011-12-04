using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Controllers;
using Trakker.Data.Services;
using Trakker.Attributes;
using AutoMapper;
using Trakker.Data;
using Trakker.Data.Repositories;
using System.IO;
using Trakker.Infastructure;
using Trakker.Infastructure.Uploading;
using Trakker.Models.Admin.Management;

namespace Trakker.Areas.Admin.Controllers
{
    [Authenticate]
    public partial class ManagementController : MasterController
    {
        private IProjectService _projectService;

        public ManagementController(IProjectService projectService, ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
            : base(ticketService, userRepo, projectRepo, ticketRepo)
        {
            _projectService = projectService;
        }

        public virtual ActionResult Index()
        {
            return View(new IndexModel());
        }

        #region User

        public virtual ActionResult BrowseUsers()
        {
            var paginatedUsers = _userRepo.GetUsersPaginated(1, 10);

            return View(new BrowseUsersModel()
            {
                Users = paginatedUsers.Items,
                TotalUsers = paginatedUsers.TotalItems,
                PageSize = 10,
                CurrentPage = 1,
                Roles = _userRepo.GetRoles().ToDictionary(d => d.Id)
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
                Roles = _userRepo.GetRoles()
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

                _userRepo.Save(user);
                
                return RedirectToAction(MVC.Admin.Management.BrowseUsers());
            }

            viewModel.Roles = _userRepo.GetRoles();

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
                Roles = _userRepo.GetRoles()
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
                _userRepo.Save(user);
                
                return RedirectToRoute(MVC.Admin.Management.ViewUser(userId));
            }

            viewModel.Roles = _userRepo.GetRoles();
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
                _userRepo.Save(user);
                
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
                Projects = _projectRepo.GetProjects(),
                Users = _userRepo.GetUsers().ToDictionary(m => m.Id)
            });
        }

        public virtual ActionResult ViewProject(int projectId)
        {
            Project project = _projectRepo.GetProjectById(projectId);

            return View(new ViewProjectModel()
                {
                    Project = project,
                    Palette = _projectRepo.GetColorPaletteById(project.ColorPaletteId),
                    User = _userRepo.GetUserById(project.Lead),
                    Versions = _projectRepo.GetVersionsByProject(project)
                });
        }

        public virtual ActionResult CreateProject()
        {
            return View(new CreateProjectModel()
            {
                Users = _userRepo.GetUsers(),
                ColorPalettes = _projectRepo.GetColorPalettes()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateProject(CreateProjectModel viewModel)
        {

            if (_projectRepo.GetProjectByKey(viewModel.KeyName) != null)
            {
                ModelState.AddModelError("KeyName", "A project with this key already exists. Please choose another.");
            }

            if (_projectRepo.GetProjectByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "A project with this name already exists. Please choose another.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateProjectModel, Project>();
                Project project = Mapper.Map(viewModel, new Project());

                project.Created = DateTime.Now;
                _projectRepo.Save(project);
                
                return RedirectToAction(MVC.Admin.Management.ViewProject(project.Id));
            }


            viewModel.Users = _userRepo.GetUsers();
            viewModel.ColorPalettes = _projectRepo.GetColorPalettes();

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult EditProject(int projectId)
        {
            Project project = _projectRepo.GetProjectById(projectId);

            if (project == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<Project, EditProjectModel>();
            EditProjectModel viewModel = Mapper.Map(project, new EditProjectModel());

            viewModel.Users = _userRepo.GetUsers();
            viewModel.ColorPalettes = _projectRepo.GetColorPalettes();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult EditProject(string keyName, [Bind(Exclude = "KeyName")]EditProjectModel viewModel)
        {
            Project project = _projectRepo.GetProjectByKey(keyName);

            if (project == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            //check if the project name already exists
            Project projectSameName = _projectRepo.GetProjectByName(viewModel.Name);
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

                _projectRepo.Save(project);
                
                return RedirectToRoute(MVC.Admin.Management.ViewProject(project.Id));
            }

            viewModel.Users = _userRepo.GetUsers();
            viewModel.ColorPalettes = _projectRepo.GetColorPalettes();

            return View(viewModel);
        }
        #endregion

        #region Version
        [HttpGet]
        public virtual ActionResult ManageVersions(int projectId)
        {
            return ManageVersions(projectId, new ManageVersionsModel());
        }

        [HttpPost]
        public virtual ActionResult ManageVersions(int projectId, ManageVersionsModel model)
        {
            Project project = _projectRepo.GetProjectById(projectId);

            if (IsPost)
            {
                if (_projectRepo.GetVersionByName(model.Name) != null)
                {
                    ModelState.AddModelError("Name", "A verison with that name already exists.");
                }

                if (ModelState.IsValid)
                {
                    ProjectVersion version = new ProjectVersion
                    {
                        Name = model.Name,
                        Description = model.Description,
                        ReleaseDate = model.ReleaseDate,
                        ProjectId = project.Id
                    };

                    _projectService.AddVersion(version, _projectRepo.GetVersionById(model.AfterVersionId));

                    return RedirectToAction(MVC.Admin.Management.ManageVersions(project.Id));
                }
            }

            model.Versions = _projectRepo.GetVersionsByProject(project);
            model.Project = project;
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult EditVersion(int projectId, int versionId)
        {
            return EditVersion(projectId, versionId, new EditVersionModel());
        }

        [HttpPost]
        public virtual ActionResult EditVersion(int projectId, int versionId, EditVersionModel model)
        {
            Project project = _projectRepo.GetProjectById(projectId);
            ProjectVersion version = _projectRepo.GetVersionById(versionId);

            if (IsPost)
            {
                //if the name exists and its not the version we are editing add an error
                if (_projectRepo.GetVersionByName(model.Name) != null)
                {
                    if (_projectRepo.GetVersionByName(model.Name).Id != versionId)
                    {
                        ModelState.AddModelError("Name", "A verison with that name already exists.");
                    }
                }

                if (ModelState.IsValid)
                {
                    version.Name = model.Name;
                    version.Description = model.Description;
                    version.ReleaseDate = model.ReleaseDate;

                    _projectRepo.Save(version);

                    return RedirectToAction(MVC.Admin.Management.ManageVersions(project.Id));
                }
            }

            model.Name = version.Name;
            model.Description = version.Description;
            model.ReleaseDate = version.ReleaseDate;
            model.Project = project;
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult DeleteVersion(int projectId, int versionId)
        {
            return DeleteVersion(projectId, versionId, new DeleteVersionModel());
        }

        [HttpPost]
        public virtual ActionResult DeleteVersion(int projectId, int versionId, DeleteVersionModel model)
        {
            Project project = _projectRepo.GetProjectById(projectId);
            ProjectVersion version = _projectRepo.GetVersionById(versionId);

            if (IsPost)
            {
                _projectService.DeleteVersion(version);
            }

            model.NumberOfTicketsToBeFixed = _projectRepo.NumberOfTicketsToBeFixed(version);
            model.NumberOfTicketsFound = _projectRepo.NumberOfTicketsFound(version);
            model.Project = project;
            model.Version = version;
            model.Versions = _projectRepo.GetVersionsByProject(project);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult ReleaseVersion(int projectId, int versionId)
        {
            return ReleaseVersion(projectId, versionId, new ReleaseVersionModel());
        }

        [HttpPost]
        public virtual ActionResult ReleaseVersion(int projectId, int versionId, ReleaseVersionModel model)
        {
            Project project = _projectRepo.GetProjectById(projectId);
            ProjectVersion version = _projectRepo.GetVersionById(versionId);

            if (IsPost)
            {
                if (ModelState.IsValid)
                {
                    version.ReleaseDate = model.ReleaseDate;
                    _projectService.ReleaseVersion(version);

                    return RedirectToAction(MVC.Admin.Management.ManageVersions(project.Id));
                }
            }

            model.ReleaseDate = version.ReleaseDate;
            model.Project = project;
            model.Version = version;
            model.NumberOfTicketsOpen = _projectRepo.NumberOfTicketsOpen(version);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult UnreleaseVersion(int projectId, int versionId)
        {
            ProjectVersion version = _projectRepo.GetVersionById(versionId);
            _projectService.UnreleaseVersion(version);

            return RedirectToAction(MVC.Admin.Management.ManageVersions(projectId));
        }
        #endregion

        [HttpPost]
        public virtual ActionResult UploadFile()
        {
            Project project = _projectRepo.GetProjectById(1);

            IPathResolver pathResolver = new ProjectAvatarPathResolver("D:\\TestHome", project);
            IFileUploader fileUploader = new ImageUploader(new AvatarImageProfile());
            UploadManager uploader = new UploadManager(Request, pathResolver, fileUploader);

            uploader.Upload();

            return View();
        }

    }
}
