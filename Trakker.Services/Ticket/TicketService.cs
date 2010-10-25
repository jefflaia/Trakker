﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Data;

namespace Trakker.Services
{
    public class TicketService : ITicketService
    {
        ITicketRepository _ticketRepository;
        IProjectRepository _projectRepository;

        public TicketService(ITicketRepository ticketRepository, IProjectRepository projectRepository)
        {
            _ticketRepository = ticketRepository;
            _projectRepository = projectRepository;
        }

        public IList<Ticket> TicketList(int pageSize, int index)
        {
            return _ticketRepository.GetTickets()
                .Skip(pageSize * (index - 1))
                .Take(pageSize)
                .ToList<Ticket>();
        }

        public IList<Ticket> GetTicketsWithAssignedTo(int userId)
        {
            return _ticketRepository.GetTickets().Where(x => x.AssignedToUserId == userId).ToList<Ticket>();
        }

        public int CountTicketsWithAssignedTo(int userId)
        {
            return _ticketRepository.GetTickets().Where(x => x.AssignedToUserId == userId).Count<Ticket>();
        }

        public Category GetCategoryWithId(int id)
        {
            return _ticketRepository.GetCategories().WithId(id).Single<Category>();
        }

        public Priority GetPriorityWithId(int id)
        {
            return _ticketRepository.GetPriorities().WithId(id).Single<Priority>();
        }

        public Status GetStatusWithId(int id)
        {
            return _ticketRepository.GetStatus().WithId(id).Single<Status>();
        }

        public Comment GetCommentWithId(int id)
        {
            return _ticketRepository.GetComments().Where(x => x.CommentId == id).SingleOrDefault<Comment>() ?? null;
        }

        public IList<Comment> GetCommentsWithticketId(int id)
        {
            return _ticketRepository.GetComments().WithTicketId(id).ToList<Comment>();
        }

        public Ticket GetTicketWithId(int id)
        {
            return _ticketRepository.GetTickets().WithId(id).Single<Ticket>();
        }

        public int TotalTickets()
        {
            return _ticketRepository.GetTickets().Count<Ticket>();
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


        public IList<Category> GetAllCategories()
        {
            return _ticketRepository.GetCategories().ToList<Category>();
        }

        public IList<Status> GetAllStatus()
        {
            return _ticketRepository.GetStatus().ToList<Status>();
        }

        public IList<Priority> GetAllPriorities()
        {
            return _ticketRepository.GetPriorities().ToList<Priority>();
        }


        public string GenerateTicketKeyName(int projectId)
        {
            Project project = _projectRepository.GetProjects().WithId(projectId).SingleOrDefault<Project>();

            //test if no ticket
            int maxValue;
            string maxKeyName = (from t in _ticketRepository.GetTickets()
                                 where t.ProjectId == projectId
                                 && t.KeyName.StartsWith(project.KeyName)
                                 select t.KeyName).Max() ?? String.Empty;

            maxKeyName = maxKeyName.Replace(String.Concat(project.KeyName, "-"), String.Empty);

            if (int.TryParse(maxKeyName, out maxValue) == false)
            {
                //tryparse actually assigns 0 when false, but i do it to show its being done
                maxValue = 0;
            }

            maxValue++;

            return String.Concat(project.KeyName, "-", maxValue.ToString());
        }

        public void Save(Ticket ticket)
        {
            ticket.KeyName = GenerateTicketKeyName(ticket.ProjectId);
                                        
            _ticketRepository.Save(ticket);
        }

        public void Save(Comment comment)
        {
            _ticketRepository.Save(comment);
        }


        #region Resolution
        public void Save(Resolution resolution)
        {
            _ticketRepository.Save(resolution);
        }

        public IList<Resolution> GetAllResolutions()
        {
            return _ticketRepository.GetResolutions().ToList<Resolution>();
        }

        public Resolution GetResolutionById(int resoutionId)
        {
            return _ticketRepository.GetResolutions()
                .Where(r => r.ResolutionId == resoutionId)
                .SingleOrDefault<Resolution>() ?? null;
        }
        #endregion
    }
}
