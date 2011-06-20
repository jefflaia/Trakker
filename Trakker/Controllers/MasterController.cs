namespace Trakker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using Trakker.Data;
    using Trakker.Core;
    using Trakker.Core.IoC;
    using System.Linq.Expressions;
    using System.Web.Routing;
    using Trakker.Helpers;
    using Microsoft.Web.Mvc;
    using Trakker.Data.Services;
    using Trakker.Core.Extensions;
    using AutoMapper;
    using Trakker.Models;
    using Trakker.Data.Repositories;

    public abstract partial class MasterController : Controller
    {
        protected ITicketService _ticketService;
        protected IUserRepository _userRepo;
        protected IProjectRepository _projectRepo;
        protected ITicketRepository _ticketRepo;

        public MasterController(ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
        {
            _ticketService = ticketService;
            _userRepo = userRepo;
            _projectRepo = projectRepo;
            _ticketRepo = ticketRepo;
        }

        #region MasterPage

        protected Project _currentProject;
        public Project CurrentProject
        {
            get
            {
                if (_currentProject == null)
                {
                    return _projectRepo.GetProjectById(ProjectCookie.Read());
                }
                else
                {
                    return _currentProject;
                }
            }
            set
            {
                ProjectCookie.Create(value.Id);
                _currentProject = value;
            }
        }

        public bool IsProjectSelected()
        {
            return CurrentProject != null;
        }     

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.ViewData["SelectedItem"] = this.GetType().Name;
        }

        protected virtual new ActionResult View()
        {
            return View(ViewData.Model);
        }

        protected ActionResult View(MasterModel model)
        {
            Mapper.CreateMap<MasterModel, MasterModel>();
            return base.View(Mapper.Map(GetMasterModel(), model));
        }

        private static MasterModel CreateModel(MasterModel model, MasterModel masterModel)
        {
            Mapper.CreateMap<MasterModel, MasterModel>();
            return Mapper.Map(masterModel, model);
        }

        private MasterModel GetMasterModel()
        {
            MasterModel viewData = new MasterModel()
            {
                RecentProjects = _projectRepo.GetProjects(),
                HasCurrentProject = CurrentProject != null ? true : false,
                CurrentProject = CurrentProject,
                CurrentUser = Auth.CurrentUser,
                IsUserLoggedIn = Auth.IsUserLoggedIn(),
                NumTicketsAssignedToCurrentUser = 0
            };

            if (CurrentProject != null)
            {
                viewData.Tickets = _ticketRepo.GetNewestTicketsByProject(CurrentProject, 0, 5).Items;
            }
            else
            {
                viewData.Tickets = new List<Ticket>();
            }

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketRepo.TotalTicketsByAssignedToUser(Auth.CurrentUser);
            }

            return viewData;
        }

        #endregion

        #region Convention

        protected internal ActionResult PermanentRedirectToAction(ActionResult result)
        {
            return new CustomCodeRedirectResult(Request.RequestContext, result, 301);
        }

        protected internal ActionResult TemporaryRedirectToAction(ActionResult result)
        {
            return new CustomCodeRedirectResult(Request.RequestContext, result, 307);
        }

        #endregion
    }


}
