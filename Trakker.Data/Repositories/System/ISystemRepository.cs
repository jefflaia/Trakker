namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISystemRepository
    {
        IQueryable<ColorPalette> GetColorPalettes();
        void Save(ColorPalette palette);
        void DeleteColorPalette(int id);

        SystemSettings GetSystemSettings();
        void Save(SystemSettings settings);
        
    }
}
