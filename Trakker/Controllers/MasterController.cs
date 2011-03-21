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

    public abstract partial class MasterController : Controller
    {

        protected IProjectService _projectService;
        protected ITicketService _ticketService;
        protected IUserService _userService;
        
        public MasterController(IProjectService projectService, ITicketService ticketService, IUserService userSerivice)
        {
            _projectService = projectService;
            _ticketService = ticketService;
            _userService = userSerivice;

            UnitOfWork = WindsorContainerProvider.Resolve<IUnitOfWork>();
        }

        #region MasterPage

        protected Project _currentProject;
        public Project CurrentProject
        {
            get
            {
                if (_currentProject == null)
                {
                    return _projectService.GetProjectByProjectId(ProjectCookie.Read());
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

        public IUnitOfWork UnitOfWork { get; set; }

        /*
        public virtual RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> action)
        {
            

            MethodCallExpression body = action.Body as MethodCallExpression;

            if (body == null)
            {
                throw new InvalidOperationException("Expression must be a method call.");
            }

            if (body.Object != action.Parameters[0])
            {
                throw new InvalidOperationException("Method call must target lambda argument.");
            }

            string controllerName = typeof(TController).GetControllerName();
            string actionName = body.Method.Name;

            RouteValueDictionary parameters = LinkBuilder.BuildParameterValuesFromExpression(body);

            return RedirectToAction(actionName, controllerName, parameters);
        }

        public virtual RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   IDictionary<string, object> dictionary)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(dictionary));
        }

        public virtual RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   object values)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(values));
        }
         * */
      

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
                RecentProjects = _projectService.GetAllProjects(),
                HasCurrentProject = CurrentProject != null ? true : false,
                CurrentProject = CurrentProject,
                CurrentUser = Auth.CurrentUser,
                IsUserLoggedIn = Auth.IsUserLoggedIn(),
                NumTicketsAssignedToCurrentUser = 0
            };

            if (CurrentProject != null)
            {
                viewData.Tickets = _ticketService.GetNewestTicketsWithProjectId(CurrentProject.Id, 5);
            }
            else
            {
                viewData.Tickets = new List<Ticket>();
            }

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketService.CountTicketsWithAssignedTo(Auth.CurrentUser.Id);
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
