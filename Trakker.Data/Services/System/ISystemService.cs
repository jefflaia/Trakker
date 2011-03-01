using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data.Services
{
    public interface ISystemService
    {
        ColorPalette GetColorPaletteById(int id);
        IList<ColorPalette> GetAllColorPalettes();
        ColorPalette GetColorPaletteByName(string name);
        void Save(ColorPalette palette);

        SystemSettings GetSystemSettings();
    }
}
