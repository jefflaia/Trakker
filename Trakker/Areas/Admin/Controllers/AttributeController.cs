
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

        public ActionResult EditPriority(int priorityId)
        {
            TicketPriority priority = _ticketService.GetPriorityById(priorityId);
            if (priority == null)
            {
                throw new NotImplementedException("not found error page");
            }

            Mapper.CreateMap<TicketPriority, CreateEditPriorityModel>();
            return View(Mapper.Map(priority, new CreateEditPriorityModel()));
        }

        [HttpPost]
        public ActionResult EditPriority(int priorityId, CreateEditPriorityModel viewData)
        {
            TicketPriority priority = _ticketService.GetPriorityById(priorityId);
            if (priority == null)
            {
                throw new NotImplementedException("not found error page");
            }

            TicketPriority existingResolution = _ticketService.GetPriorityByName(viewData.Name);
            if (existingResolution != null && existingResolution.Id != priorityId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditPriorityModel, TicketPriority>();
                Mapper.Map(viewData, priority);
                _ticketService.Save(priority);
                UnitOfWork.Commit();
                return RedirectToRoute("CreatePriority");
            }

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

        [HttpGet]
        public ActionResult EditResolution(int resolutionId)
        {
            TicketResolution resolution = _ticketService.GetResolutionById(resolutionId);
            if (resolution == null)
            {
                throw new NotImplementedException("not found error page");
            }

            Mapper.CreateMap<TicketResolution, CreateEditResolutionModel>();
            return View(Mapper.Map(resolution, new CreateEditResolutionModel()));
        }

        [HttpPost]
        public ActionResult EditResolution(int resolutionId, CreateEditResolutionModel viewData)
        {
            TicketResolution resolution = _ticketService.GetResolutionById(resolutionId);
            if (resolution == null)
            {
                throw new NotImplementedException("not found error page");
            }
            
            TicketResolution existingResolution = _ticketService.GetResolutionByName(viewData.Name);
            if (existingResolution != null && existingResolution.Id != resolutionId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditResolutionModel, TicketResolution>();
                Mapper.Map(viewData, resolution);
                _ticketService.Save(resolution);
                UnitOfWork.Commit();
                return RedirectToRoute("CreateResolution");
            }

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

        #region Type
        public ActionResult CreateType()
        {
            return View(new CreateEditTypeModel()
            {
                Types = _ticketService.GetAllTypes()
            });
        }

        [HttpPost]
        public ActionResult CreateType(CreateEditTypeModel viewModel)
        {
            if (_ticketService.GetTypeByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTypeModel, TicketType>();
                TicketType type = Mapper.Map(viewModel, new TicketType());
                _ticketService.Save(type);
                UnitOfWork.Commit();
                return RedirectToRoute("CreateType");
            }

            viewModel.Types = _ticketService.GetAllTypes();
            return View(viewModel);
        }

        public ActionResult EditType(int typeId)
        {
            TicketType type = _ticketService.GetTypeById(typeId);

            if (type == null)
            {
                throw new NotImplementedException("Throw not found error");
            }

            Mapper.CreateMap<TicketType, CreateEditTypeModel>();
            return View(Mapper.Map(type, new CreateEditTypeModel()));
        }

        [HttpPost]
        public ActionResult EditType(int typeId, CreateEditTypeModel viewModel)
        {
            TicketType type = _ticketService.GetTypeById(typeId);
            if (type == null) throw new NotImplementedException("Throw not found error");

            TicketType existingType = _ticketService.GetTypeByName(viewModel.Name);
            if (existingType != null && existingType.Id != typeId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTypeModel, TicketType>();
                Mapper.Map(viewModel, type);

                _ticketService.Save(type);
                UnitOfWork.Commit();
                return RedirectToRoute("CreateType");
            }

            return View(viewModel);
        }
        #endregion
    }
}
