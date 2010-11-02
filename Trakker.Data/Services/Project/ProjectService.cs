

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
        protected const string COOKIE_NAME = "Project";


        public ProjectService(IProjectRepository projectRepository, ITicketRepository ticketRepository)
        {
            _projectRepository = projectRepository;
            _ticketRepository = ticketRepository;

            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(COOKIE_NAME);

            if (cookie != null)
            {
                int projectId;
                bool result = Int32.TryParse(cookie.Value, out projectId);

                SelectedProjectId = projectId;
            }

        }

        public static int _selectedProjectId;
        public static int SelectedProjectId { 
            get
            {
                if (_selectedProjectId <= 0)
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(COOKIE_NAME);

                    if (cookie != null)
                    {
                        int projectId;
                        bool result = Int32.TryParse(cookie.Value, out projectId);

                        _selectedProjectId = projectId;
                    }
                }

                return _selectedProjectId;
            }
            set
            {
                HttpCookie cookie = new HttpCookie(COOKIE_NAME)
                {
                    Value = value.ToString()
                };
             
                HttpContext.Current.Response.Cookies.Add(cookie);

                _selectedProjectId = value;
            }
        }

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

        public void Save(Project project)
        {
            //exsiting project
            //override created / keyname with old values. These values are not allowed to be changed.
            if (project.ProjectId > 0)
            {
                Project oldProject = _projectRepository.GetProjects().Where(p => p.ProjectId == project.ProjectId).Single();
                project.KeyName = oldProject.KeyName;
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
    }
}
