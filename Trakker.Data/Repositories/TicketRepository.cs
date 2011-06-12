﻿
namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Linq;
    using System.Web;
    using AutoMapper;
    using Trakker.Core.Extensions;

    using Sql = Trakker.Data.Access;
    using NHibernate;
    using NHibernate.Criterion;

    public class TicketRepository : Repository, ITicketRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.TicketPriority> _prioritiesTable;
        protected Table<Sql.TicketType> _typeTable;
        protected Table<Sql.Ticket> _ticketsTable;
        protected Table<Sql.TicketStatus> _statusesTable;
        protected Table<Sql.Comment> _commentsTable;
        protected Table<Sql.TicketResolution> _resolutionTable;

        public TicketRepository(IDataContextProvider dataContextProvider, ISession session) : base(session)
        {
            DataContext dataContext = dataContextProvider.DataContext;

            _prioritiesTable = dataContext.GetTable<Sql.TicketPriority>();
            _typeTable = dataContext.GetTable<Sql.TicketType>();
            _ticketsTable = dataContext.GetTable<Sql.Ticket>();
            _statusesTable = dataContext.GetTable<Sql.TicketStatus>();
            _commentsTable = dataContext.GetTable<Sql.Comment>();
            _resolutionTable = dataContext.GetTable<Sql.TicketResolution>();
        }

        #region Status
        public TicketStatus GetStatusById(int id)
        {
            return GetById<TicketStatus>(id);
        }

        public TicketStatus GetStatusByName(string name)
        {
            return GetSingleBy<TicketStatus>(m => m.Name, name);
        }
        
        public IList<TicketStatus> GetStatus()
        {
            return GetAll<TicketStatus>();
        }

        public void Save(TicketStatus status)
        {
            base.Save(status);
        }

        #endregion

        #region Comment

        public Comment GetCommentById(int id)
        {
            return GetById<Comment>(id);
        }

        public IList<Comment> GetComments()
        {
            return GetAll<Comment>();
        }

        public IList<Comment> GetCommentsByUser(User user, int page, int pageSize)
        {
            return GetManyBy<Comment>(m => m.UserId, user.Id);
        }

        public IList<Comment> GetCommentsByTicket(Ticket ticket)
        {
            return GetManyBy<Comment>(m => m.TicketId, ticket.Id);
        }

        public Paginated<Comment> GetCommentsByTicket(Ticket ticket, int page, int pageSize)
        {

            return GetPaginated<Comment>(page, pageSize);
        }

        public void Save(Comment comment)
        {
            base.Save(comment);
        }
        #endregion

        #region Ticket

        public Ticket GetTicketById(int id)
        {
            return GetById<Ticket>(id);
        }

        public int TotalTickets()
        {
            // Get the total row count in the database.
            return Session.CreateCriteria<Ticket>()
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }

        public int TotalTicketsByAssignedToUser(User user)
        {
            // Get the total row count in the database.
            return Session.CreateCriteria<Ticket>()
                .Add(Restrictions.Eq("AssignedToUserId", user.Id))
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }

        public Ticket GetTicketByKey(string key)
        {
            return Session.CreateQuery("from Ticket t where t.KeyName = ?")
                .SetString(0, key)
                .UniqueResult<Ticket>();
        }

        public Paginated<Ticket> GetTicketsByProject(Project project, int page, int pageSize)
        {
            ICriteria criteria = Session.CreateCriteria<Ticket>()
               .Add(Expression.Eq("ProjectId", project.Id));

            return GetPaginated<Ticket>(criteria, page, pageSize);
        }

        public Paginated<Ticket> GetNewestTicketsByProject(Project project, int page, int pageSize)
        {
            ICriteria criteria = Session.CreateCriteria<Ticket>()
                .Add(Expression.Eq("ProjectId", project.Id))
                .AddOrder(Order.Desc("Created"));

            return GetPaginated<Ticket>(criteria, page, pageSize);
        }

        public IList<Ticket> GetTicketsByAssignedToUser(User user)
        {
            return Session.CreateQuery("from Ticket t where t.AssignedToUserId = ?")
                .SetInt32(0, user.Id)
                .List<Ticket>();
        }

        public IQueryable<Ticket> GetTickets()
        {
            return from t in _ticketsTable
                   select new Ticket
                   {
                       Id = t.Id,
                       Description = t.Description,
                       Created = t.Created,
                       DueDate = t.DueDate,
                       PriorityId = t.PriorityId,
                       CategoryId = t.CategoryId,
                       ResolutionId = t.ResolutionId,
                       Summary = t.Summary,
                       StatusId = t.StatusId,
                       KeyName = t.KeyName,
                       AssignedByUserId = t.AssignedByUserId,
                       AssignedToUserId = t.AssignedToUserId,
                       ProjectId = t.ProjectId,
                       CreatedByUserId = t.CreatedByUserId,
                       IsClosed = t.IsClosed
                   };
        }

        public void Save(Ticket ticket)
        {
            if (ticket.Id == 0)
            {
                ticket.Created = DateTime.Now;
            }

            ticket.Description = ticket.Description ?? string.Empty; //if null make it empty
            base.Save(ticket);
        }
        
        #endregion

        #region Type
        public TicketType GetTypeById(int id)
        {
            return GetById<TicketType>(id);
        }

        public TicketType GetTypeByName(string name)
        {
            return GetSingleBy<TicketType>(m => m.Name, name);
        }

        public IList<TicketType> GetTypes()
        {
            return GetAll<TicketType>();
        }

        public void Save(TicketType type)
        {
            base.Save(type);
        }
        
        #endregion

        #region Priority
        public TicketPriority GetPriorityById(int id)
        {
            return GetById<TicketPriority>(id);
        }

        public TicketPriority GetPriorityByName(string name)
        {
            return GetSingleBy<TicketPriority>(m => m.Name, name);
        }

        public IList<TicketPriority> GetPriorities()
        {
            return GetAll<TicketPriority>();
        }

        public void Save(TicketPriority priority)
        {
            base.Save(priority);
        }

        #endregion

        #region Resolution
        public TicketResolution GetResolutionById(int id)
        {
            return GetById<TicketResolution>(id);
        }

        public TicketResolution GetResolutionByName(string name)
        {
            return GetSingleBy<TicketResolution>(m => m.Name, name);
        }

        public IList<TicketResolution> GetResolutions()
        {
            return GetAll<TicketResolution>();
        }

        public void Save(TicketResolution resolution)
        {
            base.Save(resolution);
        }
        #endregion
    }
}