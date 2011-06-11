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

        Property<T> GetPropertyByName<T>(string name);
        void Save<T>(Property<T> property);
        
    }
}
