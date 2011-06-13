
namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IProjectRepository
    {
        IList<Project> GetProjects();
        Project GetProjectByName(string name);
        Project GetProjectByKey(string key);
        Project GetProjectById(int id);
        void Save(Project project);


        ColorPalette GetColorPaletteById(int id);
        ColorPalette GetColorPaletteByName(string name);
        IList<ColorPalette> GetColorPalettes();
        void Save(ColorPalette palette);


        void SaveComponent(Trakker.Data.Component component);
    }
}
