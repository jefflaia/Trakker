
namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using Trakker.Data;

    public interface IProjectService
    {

        //Project SelectedProject { get; set; }


        IList<Trakker.Data.Project> GetAllProjects();
        Project GetProjectByProjectId(int id);
        Project GetProjectByKeyName(string keyName);
        void Save(Project project);
    }
}
