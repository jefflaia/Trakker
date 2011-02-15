namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;
    using System.Globalization;

    public class SystemService : ISystemService
    {
        protected ISystemRepository _systemRepository;

        public SystemService(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public ColorPalette GetColorPaletteById(int id)
        {
            return _systemRepository.GetColorPalettes().Where(p => p.Id == id).SingleOrDefault() ?? null;
        }

        public IList<ColorPalette> GetAllColorPalettes()
        {
            return _systemRepository.GetColorPalettes().ToList();
        }

        public void Save(ColorPalette palette)
        {
            palette.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palette.Name);
            _systemRepository.Save(palette);
        }

        public ColorPalette GetColorPaletteByName(string name)
        {
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            return _systemRepository.GetColorPalettes()
                .Where(m => m.Name == name).SingleOrDefault() ?? null;
        }
    }
}