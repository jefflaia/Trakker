
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

        void SaveComponent(Trakker.Data.Component component);
    }
}
