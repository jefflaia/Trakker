

namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;

    public class TicketService : ITicketService
    {
        ITicketRepository _ticketRepository;
        IProjectRepository _projectRepository;

        public TicketService(ITicketRepository ticketRepository, IProjectRepository projectRepository)
        {
            _ticketRepository = ticketRepository;
            _projectRepository = projectRepository;
        }

        #region Ticket
        public string GenerateTicketKey(Project project)
        {
            return String.Concat(project.KeyName, "-", project.TicketIndex);
        }

        public void AddTicketToProject(Ticket ticket, Project project)
        {
            project.TicketIndex++;

            _projectRepository.Save(project);
            _ticketRepository.Save(ticket);
        }
        #endregion


    }
}
