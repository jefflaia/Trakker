
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
    using Trakker.Data.Repositories;

    public partial class AttributeController : MasterController
    {
        public AttributeController(ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
            : base(ticketService, userRepo, projectRepo, ticketRepo)
        {
        }

        public virtual ActionResult Index()
        {
            return View(new AttributeIndexModel());
        }

        #region Priority

        public virtual ActionResult CreatePriority()
        {
            return View(new CreateEditPriorityModel()
            {
                Priorities = _ticketRepo.GetPriorities()
            });
        }

        [HttpPost]
        public virtual ActionResult CreatePriority(CreateEditPriorityModel viewData)
        {
            if (_ticketRepo.GetPriorityByName(viewData.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }
            
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditPriorityModel, TicketPriority>();
                TicketPriority priority = Mapper.Map(viewData, new TicketPriority());

                _ticketRepo.Save(priority);
                
                return RedirectToAction(MVC.Admin.Attribute.CreatePriority());
            }

            viewData.Priorities = _ticketRepo.GetPriorities();

            return View(viewData);
        }

        public virtual ActionResult EditPriority(int priorityId)
        {
            TicketPriority priority = _ticketRepo.GetPriorityById(priorityId);
            if (priority == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<TicketPriority, CreateEditPriorityModel>();
            return View(Mapper.Map(priority, new CreateEditPriorityModel()));
        }

        [HttpPost]
        public virtual ActionResult EditPriority(int priorityId, CreateEditPriorityModel viewData)
        {
            TicketPriority priority = _ticketRepo.GetPriorityById(priorityId);
            if (priority == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            TicketPriority existingResolution = _ticketRepo.GetPriorityByName(viewData.Name);
            if (existingResolution != null && existingResolution.Id != priorityId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditPriorityModel, TicketPriority>();
                Mapper.Map(viewData, priority);
                _ticketRepo.Save(priority);
                
                return RedirectToAction(MVC.Admin.Attribute.CreatePriority());
            }

            return View(viewData);
        }
        #endregion

        #region Resolution
        public virtual ActionResult CreateResolution()
        {
            return View(new CreateEditResolutionModel()
            {
                Resolutions = _ticketRepo.GetResolutions()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateResolution(CreateEditResolutionModel viewData)
        {
            if (_ticketRepo.GetResolutionByName(viewData.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditResolutionModel, TicketResolution>();
                TicketResolution resolution = Mapper.Map(viewData, new TicketResolution());

                _ticketRepo.Save(resolution);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateResolution());
            }

            viewData.Resolutions = _ticketRepo.GetResolutions();

            return View(viewData);
        }

        [HttpGet]
        public virtual ActionResult EditResolution(int resolutionId)
        {
            TicketResolution resolution = _ticketRepo.GetResolutionById(resolutionId);
            if (resolution == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<TicketResolution, CreateEditResolutionModel>();
            return View(Mapper.Map(resolution, new CreateEditResolutionModel()));
        }

        [HttpPost]
        public virtual ActionResult EditResolution(int resolutionId, CreateEditResolutionModel viewData)
        {
            TicketResolution resolution = _ticketRepo.GetResolutionById(resolutionId);
            if (resolution == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            TicketResolution existingResolution = _ticketRepo.GetResolutionByName(viewData.Name);
            if (existingResolution != null && existingResolution.Id != resolutionId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditResolutionModel, TicketResolution>();
                Mapper.Map(viewData, resolution);
                _ticketRepo.Save(resolution);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateResolution());
            }

            return View(viewData);
        }
        #endregion

        #region status
        [HttpGet]
        public virtual ActionResult CreateStatus()
        {
            return View(new CreateEditStatusModel() { 
                Statuses = _ticketRepo.GetStatus()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateStatus(CreateEditStatusModel viewModel)
        {
            if (_ticketRepo.GetStatusByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "The value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditStatusModel, TicketStatus>();
                TicketStatus status = Mapper.Map(viewModel, new TicketStatus());

                _ticketRepo.Save(status);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateStatus());
            }

            viewModel.Statuses = _ticketRepo.GetStatus();
            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult EditStatus(int statusId)
        {
            TicketStatus status = _ticketRepo.GetStatusById(statusId);

            if (status == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<TicketStatus, CreateEditStatusModel>();
            return View(Mapper.Map(status, new CreateEditStatusModel()));
        }

        [HttpPost]
        public virtual ActionResult EditStatus(int statusId, CreateEditStatusModel viewModel)
        {
            TicketStatus status = _ticketRepo.GetStatusById(statusId);
            if (status == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            TicketStatus existingStatus = _ticketRepo.GetStatusByName(viewModel.Name);
            if (existingStatus != null && existingStatus.Id != statusId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }
            
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditStatusModel, TicketStatus>();
                Mapper.Map(viewModel, status);

                _ticketRepo.Save(status);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateStatus());               
            }

            return View(viewModel);
        }
        
        #endregion

        #region Type
        public virtual ActionResult CreateType()
        {
            return View(new CreateEditTypeModel()
            {
                Types = _ticketRepo.GetTypes()
            });
        }

        [HttpPost]
        public virtual ActionResult CreateType(CreateEditTypeModel viewModel)
        {
            if (_ticketRepo.GetTypeByName(viewModel.Name) != null)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTypeModel, TicketType>();
                TicketType type = Mapper.Map(viewModel, new TicketType());
                _ticketRepo.Save(type);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateType()); ;
            }

            viewModel.Types = _ticketRepo.GetTypes();
            return View(viewModel);
        }

        public virtual ActionResult EditType(int typeId)
        {
            TicketType type = _ticketRepo.GetTypeById(typeId);

            if (type == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<TicketType, CreateEditTypeModel>();
            return View(Mapper.Map(type, new CreateEditTypeModel()));
        }

        [HttpPost]
        public virtual ActionResult EditType(int typeId, CreateEditTypeModel viewModel)
        {
            TicketType type = _ticketRepo.GetTypeById(typeId);
            if (type == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            TicketType existingType = _ticketRepo.GetTypeByName(viewModel.Name);
            if (existingType != null && existingType.Id != typeId)
            {
                ModelState.AddModelError("Name", "This value already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTypeModel, TicketType>();
                Mapper.Map(viewModel, type);

                _ticketRepo.Save(type);
                
                return RedirectToAction(MVC.Admin.Attribute.CreateType());
            }

            return View(viewModel);
        }
        #endregion
    }
}
