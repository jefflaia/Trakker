

namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;
    using System.Web;


    public class ProjectService : IProjectService
    {
        protected IProjectRepository _projectRepository;
        protected ITicketRepository _ticketRepository;

        public ProjectService(IProjectRepository projectRepository, ITicketRepository ticketRepository)
        {
            _projectRepository = projectRepository;
            _ticketRepository = ticketRepository;
        }

        #region Project
        public IList<Project> GetAllProjects()
        {
            return _projectRepository.GetProjects().ToList<Project>();
        }

        public Project GetProjectByProjectId(int id)
        {
            return _projectRepository.GetProjects().WithId(id).SingleOrDefault<Project>() ?? null;
        }

        public Project GetProjectByKeyName(string keyName)
        {
            return _projectRepository.GetProjects().WithKeyName(keyName).SingleOrDefault<Project>() ?? null;
        }

        public Project GetProjectByName(string name)
        {
            return _projectRepository.GetProjects()
                .Where(m => m.Name == name)
                .SingleOrDefault<Project>() ?? null;
        }

        public void Save(Project project)
        {
            //exsiting project
            //override created / keyname with old values. These values are not allowed to be changed.
            if (project.Id > 0)
            {
                Project oldProject = _projectRepository.GetProjects().Where(p => p.Id == project.Id).Single();
                project.KeyName = oldProject.KeyName.ToUpper();
                project.Created = oldProject.Created;
            }
            //new project
            else
            {
                project.Created = DateTime.Now;
                project.KeyName = project.KeyName.ToUpper();
            }
            
            _projectRepository.Save(project);
        }
        #endregion
    }
}
