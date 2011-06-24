

namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;
    using Trakker.Data.Utilities;

    public class TicketService : ITicketService
    {
        ITicketRepository _ticketRepository;
        IProjectRepository _projectRepository;
        IUnitOfWork _uow;

        public TicketService(IUnitOfWork uow, ITicketRepository ticketRepository, IProjectRepository projectRepository)
        {
            _ticketRepository = ticketRepository;
            _projectRepository = projectRepository;
            _uow = uow;
        }

        #region Ticket
        public string GenerateTicketKey(Project project)
        {
            return String.Concat(project.KeyName, "-", project.TicketIndex);
        }

        public void AddTicketToProject(Ticket ticket, Project project)
        {
            _uow.Begin();

            project.TicketIndex++;
            ticket.ProjectId = project.Id;

            _projectRepository.Save(project);
            _ticketRepository.Save(ticket);
            _uow.Commit();

        }
        #endregion


    }
}
