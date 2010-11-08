namespace Trakker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using Trakker.Data;
    using Trakker.ViewData.SharedData;
    using Trakker.Core;
    using Trakker.IoC;
    using System.Linq.Expressions;
    using System.Web.Routing;
    using Trakker.Helpers;
    using Microsoft.Web.Mvc;
    using Trakker.Data.Services;
    using Trakker.Core.Extensions;
    using AutoMapper;

    public abstract class MasterController : Controller
    {

        protected IProjectService _projectService;
        protected ITicketService _ticketService;
        protected IUserService _userService;
        
        const string CURRENT_PROJECT_COOKIE_NAME = "Project";

        public MasterController(IProjectService projectService, ITicketService ticketService, IUserService userSerivice)
        {
            _projectService = projectService;
            _ticketService = ticketService;
            _userService = userSerivice;

            UnitOfWork = WindsorContainerProvider.Resolve<IUnitOfWork>();
        }

        protected Project _currentProject;
        public Project CurrentProject
        {
            get
            {
                if (_currentProject == null)
                {
                    HttpCookie cookie = HttpContext.Request.Cookies.Get(CURRENT_PROJECT_COOKIE_NAME);

                    if (cookie != null)
                    {
                        int projectId;
                        bool success = Int32.TryParse(cookie.Value, out projectId);

                        if (success)
                        {
                            _currentProject = _projectService.GetProjectByProjectId(projectId);
                        }
                    }
                }

                return _currentProject;
            }
            set
            {
                HttpCookie cookie = new HttpCookie(CURRENT_PROJECT_COOKIE_NAME)
                {
                    Value = value.ProjectId.ToString()
                };

                HttpContext.Response.Cookies.Add(cookie);

                _currentProject = value;
            }
        } 

        public IUnitOfWork UnitOfWork { get; set; }        
        
        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> action)
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

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   IDictionary<string, object> dictionary)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(dictionary));
        }

        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                   object values)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return RedirectToAction(actionName, controllerName,
                                    new RouteValueDictionary(values));
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

        protected ActionResult View(MasterViewData model)
        {
            Mapper.CreateMap<MasterViewData, MasterViewData>();
            return base.View(Mapper.Map(GetMasterViewData(), model));
        }

        private static MasterViewData CreateModel(MasterViewData model, MasterViewData masterModel)
        {
            Mapper.CreateMap<MasterViewData, MasterViewData>();
            return Mapper.Map(masterModel, model);
        }

        private MasterViewData GetMasterViewData()
        {
            MasterViewData viewData = new MasterViewData()
            {
                RecentProjects = _projectService.GetAllProjects(),
                HasCurrentProject = true,
                CurrentProject = CurrentProject,
                CurrentUser = _userService.CurrentUser,
                IsUserLoggedIn = _userService.IsUserLoggedIn(),
                NumTicketsAssignedToCurrentUser = 0
            };

            if (CurrentProject != null)
            {
                viewData.Tickets = _ticketService.GetNewestTicketsWithProjectId(CurrentProject.ProjectId, 5);
            }
            else
            {
                viewData.Tickets = new List<Ticket>();
            }

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketService.CountTicketsWithAssignedTo(_userService.CurrentUser.UserId);
            }

            return viewData;
        }

         
    }


}
