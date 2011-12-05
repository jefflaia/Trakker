
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


        void Save(Trakker.Data.Component component);

        void Save(ProjectVersion version);
        void IncrememtOrderingAfterVersion(ProjectVersion version);
        ProjectVersion GetVersionById(int id);
        ProjectVersion GetVersionByName(string name);
        int NumberOfTicketsToBeFixed(ProjectVersion version);
        int NumberOfTicketsFound(ProjectVersion version);
        int NumberOfTicketsOpen(ProjectVersion version);

        /// <summary>   Gets all by versions for the specificed project ordered by SortOrder asc. </summary>
        ///
        /// <param name="project">  The project. </param>
        ///
        /// <returns>   all versions by project. </returns>
        IList<ProjectVersion> GetVersionsByProject(Project project);

        void Delete(ProjectVersion version);

        void RemoveVersionFromTickets(ProjectVersion version);

        
    }
}
