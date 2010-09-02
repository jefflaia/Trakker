using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;
using System.Web;


namespace Trakker.Services
{
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
            if (project.ProjectId > 0 && project.KeyName != null)
            {
                Project oldProject = _projectRepository.GetProjects().WithId(project.ProjectId).Single<Project>();

                //the keyName has changed need to update all tickets for this project ot reflect this change
                if (oldProject.KeyName.CompareTo(project.KeyName) != 0)
                {
                    IList<Ticket> tickets = _ticketRepository.GetTickets().WithProjectId(project.ProjectId).ToList<Ticket>();
                    
                    foreach (Ticket ticket in tickets)
                    {
                          ticket.KeyName = ticket.KeyName.Replace(oldProject.KeyName, project.KeyName);
                          _ticketRepository.Save(ticket);
                    }
                }
            }

            _projectRepository.Save(project);
              
        }
    }
}
