using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

/*
namespace Trakker.Controllers
{
    public abstract class BaseMasterController : Controller
    {
        /// <summary>
        /// Views this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual new ActionResult View()
        {
            return View(Model.Model);
        }

        /// <summary>
        /// Views the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual ActionResult View(MasterModel model)
        {
            var masterModel = GetMasterModel();
            MasterModel wrapper = CreateModel(model, masterModel);

            return base.View(wrapper);
        }

        /// <summary>
        /// Gets the master view model.
        /// override this in your master controller.
        /// </summary>
        /// <returns></returns>
        protected virtual MasterModel GetMasterModel()
        {
            return new MasterModel();
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="masterModel">The master model.</param>
        /// <returns></returns>
        private static MasterModel CreateModel(MasterModel model, MasterModel masterModel)
        {
            model.CurrentProject = masterModel.CurrentProject;
            model.CurrentUser = masterModel.CurrentUser;
            model.HasCurrentProject = masterModel.HasCurrentProject;
            model.IsUserLoggedIn = masterModel.IsUserLoggedIn;
            model.NumTicketsAssignedToCurrentUser = masterModel.NumTicketsAssignedToCurrentUser;
            model.Projects = masterModel.Projects;
            model.Tickets = masterModel.Tickets;

            return model;
        }

        protected override MasterModel GetMasterModel()
        {
            MasterModel viewData = new MasterModel()
            {
                Projects = _projectService.GetAllProjects(),
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
*/