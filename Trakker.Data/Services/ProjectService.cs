

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

        #endregion
    }
}
