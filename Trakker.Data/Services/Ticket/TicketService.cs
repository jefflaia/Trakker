﻿

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
        public Ticket GetTicketWithId(int id)
        {
            return _ticketRepository.GetTickets().WithId(id).Single<Ticket>();
        }

        public IList<Ticket> TicketList(int pageSize, int index)
        {
            return _ticketRepository.GetTickets()
                .Skip(pageSize * (index - 1))
                .Take(pageSize)
                .ToList<Ticket>();
        }


        public int TotalTickets()
        {
            return _ticketRepository.GetTickets().Count<Ticket>();
        }

        public int CountTicketsWithAssignedTo(int userId)
        {
            return _ticketRepository.GetTickets().Where(x => x.AssignedToUserId == userId).Count<Ticket>();
        }

        public Ticket GetTicketWithKeyName(string keyName)
        {
            return _ticketRepository.GetTickets().WithKeyName(keyName).SingleOrDefault<Ticket>() ?? null;
        }

        public IList<Ticket> GetNewestTicketsWithProjectId(int projectId, int limit)
        {
            return _ticketRepository.GetTickets()
                .WithProjectId(projectId)
                .OrderByDescending<Ticket, DateTime>(x=>x.Created)
                .Take(limit)                  
                .ToList<Ticket>();
        }

        public IList<Ticket> GetTicketsWithAssignedTo(int userId)
        {
            return _ticketRepository.GetTickets().Where(x => x.AssignedToUserId == userId).ToList<Ticket>();
        }

        public string GenerateTicketKeyName(Project project)
        {
            return String.Concat(project.KeyName, "-", project.TicketIndex);
        }

        public void Save(Ticket ticket)
        {
            Project project = _projectRepository.GetProjects().WithId(ticket.ProjectId).SingleOrDefault<Project>();
            project.TicketIndex++;

            if (ticket.Id == 0)
            {
                ticket.Created = DateTime.Now;
            }
            else
            {
                Ticket oldTicket = _ticketRepository.GetTickets().WithId(ticket.Id).Single();
                ticket.Created = oldTicket.Created; //override any date comming in
            }


            ticket.KeyName = GenerateTicketKeyName(project);
            ticket.Description = ticket.Description ?? string.Empty; //if null make it empty

            _projectRepository.Save(project);
            _ticketRepository.Save(ticket);
        }
        #endregion

        #region Category
        public IList<TicketType> GetAllCategories()
        {
            return _ticketRepository.GetCategories().ToList<TicketType>();
        }

        public TicketType GetCategoryWithId(int id)
        {
            return _ticketRepository.GetCategories().WithId(id).Single<TicketType>();
        }
        #endregion

        #region Status
        public IList<TicketStatus> GetAllStatus()
        {
            return _ticketRepository.GetStatus().ToList<TicketStatus>();
        }

        public TicketStatus GetStatusWithId(int id)
        {
            return _ticketRepository.GetStatus().WithId(id).Single<TicketStatus>();
        }

        public TicketStatus GetStatusByName(string name)
        {
            return _ticketRepository.GetStatus().Where(s => s.Name == name).SingleOrDefault();
        }

        public void Save(TicketStatus status)
        {
            _ticketRepository.Save(status);
        }
        #endregion

        #region priority
        public IList<TicketPriority> GetAllPriorities()
        {
            return _ticketRepository.GetPriorities().ToList<TicketPriority>();
        }

        public TicketPriority GetPriorityByName(string name)
        {
            return _ticketRepository.GetPriorities().Where(m => m.Name == name).Single();
        }

        public void Save(TicketPriority priority)
        {
            _ticketRepository.Save(priority);
        }

        public TicketPriority GetPriorityWithId(int id)
        {
            return _ticketRepository.GetPriorities().WithId(id).Single<TicketPriority>();
        }
        #endregion

        #region Comment
        public void Save(Comment comment)
        {
            _ticketRepository.Save(comment);
        }

        public Comment GetCommentWithId(int id)
        {
            return _ticketRepository.GetComments().Where(x => x.Id == id).SingleOrDefault<Comment>() ?? null;
        }

        public IList<Comment> GetCommentsWithticketId(int id)
        {
            return _ticketRepository.GetComments().WithTicketId(id).ToList<Comment>();
        }
        #endregion

        #region Resolution
        public void Save(TicketResolution resolution)
        {
            _ticketRepository.Save(resolution);
        }

        public TicketResolution GetResolutionByName(string name)
        {
           return _ticketRepository.GetResolutions().Where(m => m.Name == name).Single();
        }

        public IList<TicketResolution> GetAllResolutions()
        {
            return _ticketRepository.GetResolutions().ToList<TicketResolution>();
        }

        public TicketResolution GetResolutionById(int resoutionId)
        {
            return _ticketRepository.GetResolutions()
                .Where(r => r.Id == resoutionId)
                .SingleOrDefault<TicketResolution>() ?? null;
        }
        #endregion
    }
}
