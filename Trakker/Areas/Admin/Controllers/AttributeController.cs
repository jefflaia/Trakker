
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
            return View(new CreateEditPriorityModel()
            {
                Priorities = _ticketService.GetAllPriorities()
            });
        }

        [HttpPost]
        public ActionResult CreatePriority(CreateEditPriorityModel viewData)
        {
            if (_ticketService.GetPriorityByName(viewData.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }
            
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditPriorityModel, TicketPriority>();
                TicketPriority priority = Mapper.Map(viewData, new TicketPriority());

                _ticketService.Save(priority);
                UnitOfWork.Commit();
            }

            viewData.Priorities = _ticketService.GetAllPriorities();

            return View(viewData);
        }
        #endregion

        #region Resolution
        public ActionResult CreateResolution()
        {
            return View(new CreateEditResolutionModel()
            {
                Resolutions = _ticketService.GetAllResolutions()
            });
        }

        [HttpPost]
        public ActionResult CreateResolution(CreateEditResolutionModel viewData)
        {
            if (_ticketService.GetResolutionByName(viewData.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditResolutionModel, TicketResolution>();
                TicketResolution resolution = Mapper.Map(viewData, new TicketResolution());

                _ticketService.Save(resolution);
                UnitOfWork.Commit();
            }

            viewData.Resolutions = _ticketService.GetAllResolutions();

            return View(viewData);
        }
        #endregion

        #region status
        [HttpGet]
        public ActionResult CreateStatus()
        {
            return View(new CreateEditStatusModel() { 
                Statuses = _ticketService.GetAllStatus()
            });
        }

        [HttpPost]
        public ActionResult CreateStatus(CreateEditStatusModel viewModel)
        {
            if (_ticketService.GetStatusByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "The value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditStatusModel, TicketStatus>();
                TicketStatus status = Mapper.Map(viewModel, new TicketStatus());

                _ticketService.Save(status);
                UnitOfWork.Commit();
            }

            viewModel.Statuses = _ticketService.GetAllStatus();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditStatus(int statusId)
        {
            TicketStatus status = _ticketService.GetStatusWithId(statusId);

            if (status == null) throw new NotImplementedException("Throw not found error");

            Mapper.CreateMap<TicketStatus, CreateEditStatusModel>();
            return View(Mapper.Map(status, new CreateEditStatusModel()));
        }

        [HttpPost]
        public ActionResult EditStatus(int statusId, CreateEditStatusModel viewModel)
        {
            TicketStatus status = _ticketService.GetStatusWithId(statusId);
            if (status == null) throw new NotImplementedException("Throw not found error");

            TicketStatus existingStatus = _ticketService.GetStatusByName(viewModel.Name);
            if (existingStatus != null && existingStatus.Id != statusId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }
            
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditStatusModel, TicketStatus>();
                Mapper.Map(viewModel, status);

                _ticketService.Save(status);
                UnitOfWork.Commit();
                return RedirectToRoute("CreateStatus");                
            }

            return View(viewModel);
        }
        
        #endregion
    }
}
