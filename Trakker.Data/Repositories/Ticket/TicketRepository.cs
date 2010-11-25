
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

    public class TicketRepository : ITicketRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.TicketPriority> _prioritiesTable;
        protected Table<Sql.TicketType> _typeTable;
        protected Table<Sql.Ticket> _ticketsTable;
        protected Table<Sql.TicketStatus> _statusesTable;
        protected Table<Sql.Comment> _commentsTable;
        protected Table<Sql.TicketResolution> _resolutionTable;

        public TicketRepository(IDataContextProvider dataContextProvider)
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
        public IQueryable<TicketStatus> GetStatus()
        {
            return from s in _statusesTable
                   select new TicketStatus
                   {
                       Id = s.Id,
                       Name = s.Name,
                       Description = s.Description
                   };
        }

        public void Save(TicketStatus status)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<TicketStatus, Sql.TicketStatus>();
            Sql.TicketStatus s = Mapper.Map<TicketStatus, Sql.TicketStatus>(status);

            if (status.Id == 0)
            {
                _statusesTable.InsertOnSubmit(s);
            }
            else
            {
                _statusesTable.Attach(s);
                _statusesTable.Context.Refresh(RefreshMode.KeepCurrentValues, s);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            status.Id = s.Id;
        }

        public void DeleteStatus(int id)
        {
            _statusesTable.DeleteAllOnSubmit(from t in _statusesTable
                                             where t.Id == id
                                             select t);
        }
        #endregion

        #region Comment
        public void DeleteComment(int id)
        {
            _commentsTable.DeleteAllOnSubmit(from c in _commentsTable
                                             where c.Id == id
                                             select c);
        }

        public IQueryable<Comment> GetComments()
        {
            return from c in _commentsTable
                   select new Comment
                   {
                       Id = c.Id,
                       Body = c.Body,
                       Created = c.Created,
                       Modified = c.Modified, 
                       TicketId = c.TicketId,
                       UserId = c.UserId
                   };
        }

        public void Save(Comment comment)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Comment, Sql.Comment>();
            Sql.Comment c = Mapper.Map<Comment, Sql.Comment>(comment);

            if (comment.Id == 0)
            {
                _commentsTable.InsertOnSubmit(c);
            }
            else
            {
                _commentsTable.Attach(c);
                _commentsTable.Context.Refresh(RefreshMode.KeepCurrentValues, c);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            comment.Id = c.Id;
        }
        #endregion

        #region Ticket
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
            //map the priority from our model to the dal object
            Mapper.CreateMap<Ticket, Sql.Ticket>();
            Sql.Ticket t = Mapper.Map<Ticket, Sql.Ticket>(ticket);
                
            //check if the Ticket exists
            if (ticket.Id == 0)
            {
                _ticketsTable.InsertOnSubmit(t);
            }
            else
            {
                _ticketsTable.Attach(t);
                _ticketsTable.Context.Refresh(RefreshMode.KeepCurrentValues, t);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            ticket.Id = t.Id;
        }
        
        public void DeleteTicket(int id)
        {
            _ticketsTable.DeleteAllOnSubmit(from t in _ticketsTable
                                            where t.Id == id
                                            select t);
        }
        #endregion

        #region Type
        public void Save(TicketType category)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<TicketType, Sql.TicketType>();
            Sql.TicketType c = Mapper.Map<TicketType, Sql.TicketType>(category);

            if (category.Id == 0)
            {
                _typeTable.InsertOnSubmit(c);
            }
            else
            {
                _typeTable.Attach(c);
                _typeTable.Context.Refresh(RefreshMode.KeepCurrentValues, c);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            category.Id = c.Id;
        }

        public void DeleteCategory(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                _typeTable.DeleteAllOnSubmit(from t in _typeTable
                                                   where t.Id == id
                                                   select t);

            }
        }

        public IQueryable<TicketType> GetCategories()
        {
            return from t in _typeTable
                   select new TicketType
                   {
                       Id = t.Id,
                       Name = t.Name,
                       Description = t.Description
                   };
        }
        
        #endregion

        #region Priority
        public IQueryable<TicketPriority> GetPriorities()
        {
            return from p in _prioritiesTable
                   select new TicketPriority
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Description = p.Description,
                       HexColor = p.HexColor
                   };
        }

        public void Save(TicketPriority priority)
        {

            //map the priority from our model to the dal object
            Mapper.CreateMap<TicketPriority, Sql.TicketPriority>();
            Sql.TicketPriority p = Mapper.Map<TicketPriority, Sql.TicketPriority>(priority);

            if (priority.Id == 0)
            {
                _prioritiesTable.InsertOnSubmit(p);
            }
            else
            {
                _prioritiesTable.Attach(p);
                _prioritiesTable.Context.Refresh(RefreshMode.KeepCurrentValues, p);
            }


            //set the id 
            //needed for inserts, updates the id will stay the same
            priority.Id = p.Id;
        }

        public void DeletePriority(int id)
        {
            _prioritiesTable.DeleteAllOnSubmit(from t in _prioritiesTable
                                               where t.Id == id
                                               select t);
        }
        #endregion

        #region Resolution
        public IQueryable<TicketResolution> GetResolutions()
        {
            return from r in _resolutionTable
                   select new TicketResolution
                   {
                       Id = r.Id,
                       Name = r.Name,
                       Description = r.Description
                   };
        }

        public void Save(TicketResolution resolution)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<TicketResolution, Sql.TicketResolution>();
            Sql.TicketResolution r = Mapper.Map<TicketResolution, Sql.TicketResolution>(resolution);

            r.Description = r.Description ?? string.Empty;

            //check if the Ticket exists
            if (resolution.Id == 0)
            {
                _resolutionTable.InsertOnSubmit(r);
            }
            else
            {
                _resolutionTable.Attach(r);
                _resolutionTable.Context.Refresh(RefreshMode.KeepCurrentValues, r);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            resolution.Id = r.Id;
        }

        public void DeleteResolution(int id)
        {
            _resolutionTable.DeleteAllOnSubmit(from r in _resolutionTable
                                            where r.Id == id
                                            select r);
        }


        #endregion
    }
}