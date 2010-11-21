
namespace Trakker.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Trakker.Data.Services;
    using AutoMapper;
    using Trakker.Data;
    using Trakker.Controllers;
    using Trakker.Areas.Admin.Models;


    public class AttributeController : MasterController
    {
        public AttributeController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }

        public ActionResult Index()
        {
            return View(new AttributeIndexModel());
        }


        #region Priority

        public ActionResult CreatePriority()
        {
            return View(new CreateEditPriorityModel());
        }

        [HttpPost]
        public ActionResult CreatePriority(CreateEditPriorityModel viewData)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditPriorityModel, Priority>();
                Priority priority = Mapper.Map(viewData, new Priority());

                _ticketService.Save(priority);
                UnitOfWork.Commit();
            }

            return View(viewData);
        }
        #endregion

        #region Resolution
        public ActionResult CreateResolution()
        {
            return View(new CreateEditResolutionModel());
        }

        [HttpPost]
        public ActionResult CreateResolution(CreateEditResolutionModel viewData)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditResolutionModel, Resolution>();
                Resolution resolution = Mapper.Map(viewData, new Resolution());

                _ticketService.Save(resolution);
                UnitOfWork.Commit();
            }

            return View(viewData);
        }
        #endregion

    }
}
