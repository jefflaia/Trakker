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

    public abstract class MasterController : Controller
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

        protected IUnitOfWork UnitOfWork { get; set; }        
        
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

        /// <summary>
        /// Views this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual new ActionResult View()
        {
            return View(ViewData.Model);
        }

        /// <summary>
        /// Views the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected ActionResult View(MasterViewData model)
        {
            var masterModel = GetMasterViewData();
            MasterViewData wrapper = CreateModel(model, masterModel);

            return base.View(wrapper);
        }


        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="masterModel">The master model.</param>
        /// <returns></returns>
        private static MasterViewData CreateModel(MasterViewData model, MasterViewData masterModel)
        {
            model.CurrentProject = masterModel.CurrentProject;
            model.CurrentUser = masterModel.CurrentUser;
            model.HasCurrentProject = masterModel.HasCurrentProject;
            model.IsUserLoggedIn = masterModel.IsUserLoggedIn;
            model.NumTicketsAssignedToCurrentUser = masterModel.NumTicketsAssignedToCurrentUser;
            model.RecentProjects = masterModel.RecentProjects;
            model.Tickets = masterModel.Tickets;

            return model;
        }

        private MasterViewData GetMasterViewData()
        {
            MasterViewData viewData = new MasterViewData()
            {
                RecentProjects = _projectService.GetAllProjects(),
                HasCurrentProject = true,
                CurrentProject = _projectService.GetProjectByProjectId(ProjectService.SelectedProjectId),
                CurrentUser = _userService.CurrentUser,
                IsUserLoggedIn = _userService.IsUserLoggedIn(),
                Tickets = _ticketService.GetNewestTicketsWithProjectId(ProjectService.SelectedProjectId, 5),
                NumTicketsAssignedToCurrentUser = 0
            };

            if (viewData.CurrentUser != null)
            {
                viewData.NumTicketsAssignedToCurrentUser = _ticketService.CountTicketsWithAssignedTo(_userService.CurrentUser.UserId);
            }

            return viewData;
        }

         
    }


}
