using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Areas.Admin.Models;
using Trakker.Controllers;
using Trakker.Data.Services;
using Trakker.Areas.Admin.Models;
using AutoMapper;
using Trakker.Data;
using Trakker.Data.Repositories;

namespace Trakker.Areas.Admin.Controllers
{
    public partial class SettingsController : MasterController
    {
        protected ISystemService _systemService;

        public SettingsController(ITicketService ticketService, IUserService userService, IProjectService projectService, ISystemService systemService, IUserRepository userRepo)
            : base(projectService, ticketService, userService, userRepo)
        {
            _systemService = systemService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View(new SettingsIndexModel());
        }

        [HttpGet]
        public virtual ActionResult BrowseColorPalettes()
        {
            return View(new BrowseColorPalettesModel()
            {
                ColorPalettes = _systemService.GetAllColorPalettes(),
                SelectedColorPalette = _systemService.GetColorPaletteById(3)
            });
        }

        [HttpGet]
        public virtual ActionResult CreateColorPalette()
        {
            return View(new CreateEditColorPaletteModel());
        }

        [HttpPost]
        public virtual ActionResult CreateColorPalette(CreateEditColorPaletteModel viewModel)
        {
            if (_systemService.GetColorPaletteByName(viewModel.Name ?? String.Empty) != null)
            {
                ModelState.AddModelError("Name", "A palette with this name already exists.");
            }


            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditColorPaletteModel, ColorPalette>();
                ColorPalette palette = Mapper.Map(viewModel, new ColorPalette());

                _systemService.Save(palette);
                UnitOfWork.Commit();
                return RedirectToAction(MVC.Admin.Settings.BrowseColorPalettes());
            }

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult EditColorPalette(int paletteId)
        {
            var palette = _systemService.GetColorPaletteById(paletteId);

            if (palette == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            Mapper.CreateMap<ColorPalette, CreateEditColorPaletteModel>();
            var viewModel = Mapper.Map(_systemService.GetColorPaletteById(paletteId), new CreateEditColorPaletteModel());
            
            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult EditColorPalette(int paletteId, CreateEditColorPaletteModel viewModel)
        {
            var palette = _systemService.GetColorPaletteById(paletteId);

            if (palette == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }
            
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditColorPaletteModel, ColorPalette>();
                palette = Mapper.Map(viewModel, palette);
                _systemService.Save(palette);
                UnitOfWork.Commit();
                return RedirectToAction(MVC.Admin.Settings.BrowseColorPalettes());
            }
            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult SelectColorPalette(int paletteId)
        {
            var property = _systemService.GetPropertyByName<int>("colorPaletteId");

            property.Value = paletteId;

            _systemService.Save<int>(property);
            UnitOfWork.Commit();

            return RedirectToAction(MVC.Admin.Settings.BrowseColorPalettes());
        }
    }
}
