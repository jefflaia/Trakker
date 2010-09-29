﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using AutoMapper;

namespace Trakker.Data
{
    using Sql = Trakker.Data.Access;

    public class TicketRepository : ITicketRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.Priority> _prioritiesTable;
        protected Table<Sql.Severity> _severitiesTable;
        protected Table<Sql.Category> _categoriesTable;
        protected Table<Sql.Ticket> _ticketsTable;
        protected Table<Sql.Status> _statusesTable;
        protected Table<Sql.Comment> _commentsTable;


        public TicketRepository(IDataContextProvider dataContextProvider)
        {
            DataContext dataContext = dataContextProvider.DataContext;

            _prioritiesTable = dataContext.GetTable<Sql.Priority>();
            _severitiesTable = dataContext.GetTable<Sql.Severity>();
            _categoriesTable = dataContext.GetTable<Sql.Category>();
            _ticketsTable = dataContext.GetTable<Sql.Ticket>();
            _statusesTable = dataContext.GetTable<Sql.Status>();
            _commentsTable = dataContext.GetTable<Sql.Comment>();
        }

        public IQueryable<Severity> GetSeverities()
        {
            return from s in _severitiesTable
                   select new Severity
                   {
                       SeverityId = s.SeverityId,
                       Name = s.Name,
                       Description = s.Description,
                       HexColor = s.HexColor
                   };
        }

        public IQueryable<Priority> GetPriorities()
        {
            return from p in _prioritiesTable
                   select new Priority
                   {
                       PriorityId = p.PriorityId,
                       Name = p.Name,
                       Description = p.Description,
                       HexColor = p.HexColor
                   };
        }

        public IQueryable<Category> GetCategories()
        {
            return from t in _categoriesTable
                   select new Category
                   {
                       CategoryId = t.CategoryId,
                       Name = t.Name,
                       Description = t.Description
                   };
        }

        public IQueryable<Ticket> GetTickets()
        {
           return from t in _ticketsTable
                   select new Ticket
                   {
                       TicketId = t.TicketId,
                       Description = t.Description,
                       Created = t.Created,
                       DueDate = t.DueDate,
                       PriorityId = t.PriorityId,
                       CategoryId = t.CategoryId,
                       Summary = t.Summary,
                       StatusId = t.StatusId,
                       SeverityId = t.SeverityId,
                       KeyName = t.KeyName,
                       AssignedByUserId = t.AssignedByUserId,
                       AssignedToUserId = t.AssignedToUserId,
                       ProjectId = t.ProjectId,
                       CreatedByUserId = t.CreatedByUserId,
                       IsClosed = BitConverter.ToBoolean(BitConverter.GetBytes(t.IsClosed), 0)

                   };
        }

        public IQueryable<Status> GetStatus()
        {
            return from s in _statusesTable
                   select new Status
                   {
                       StatusId = s.StatusId,
                       Name = s.Name,
                       Description = s.Description
                   };
        }

        public IQueryable<Comment> GetComments()
        {
            return from c in _commentsTable
                   select new Comment
                   {
                       CommentId = c.CommentId,
                       Body = c.Body,
                       Created = c.Created,
                       Modified = c.Modified, 
                       TicketId = c.TicketId,
                       UserId = c.UserId
                   };
        }



        public void Save(Ticket Ticket)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Ticket, Sql.Ticket>();
            Sql.Ticket t = Mapper.Map<Ticket, Sql.Ticket>(Ticket);

            t.Description = t.Description ?? string.Empty;
            t.Created = t.Created.Equals(DateTime.MinValue) ? DateTime.Now : t.Created;

                
            //check if the Ticket exists
            if (Ticket.TicketId == 0)
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
            Ticket.TicketId = t.TicketId;
        }

        public void Save(Category category)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Category, Sql.Category>();
            Sql.Category c = Mapper.Map<Category, Sql.Category>(category);

            if (category.CategoryId == 0)
            {
                _categoriesTable.InsertOnSubmit(c);
            }
            else
            {
                _categoriesTable.Attach(c);
                _categoriesTable.Context.Refresh(RefreshMode.KeepCurrentValues, c);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            category.CategoryId = c.CategoryId;
        }

        public void Save(Priority priority)
        {

            //map the priority from our model to the dal object
            Mapper.CreateMap<Priority, Sql.Priority>();
            Sql.Priority p = Mapper.Map<Priority, Sql.Priority>(priority);

            if (priority.PriorityId == 0)
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
            priority.PriorityId = p.PriorityId;
        }

        public void Save(Status status)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Status, Sql.Status>();
            Sql.Status s = Mapper.Map<Status, Sql.Status>(status);

            if (status.StatusId == 0)
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
            status.StatusId = s.StatusId;
        }

        public void Save(Severity severity)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Severity, Sql.Severity>();
            Sql.Severity s = Mapper.Map<Severity, Sql.Severity>(severity);

            if (severity.SeverityId == 0)
            {
                _severitiesTable.InsertOnSubmit(s);
            }
            else
            {
                _severitiesTable.Attach(s);
                _severitiesTable.Context.Refresh(RefreshMode.KeepCurrentValues, s);
            }

            //set the id 
            //needed for inserts, updates the id will stay the same
            severity.SeverityId = s.SeverityId;
        }

        public void Save(Comment comment)
        {
            //map the priority from our model to the dal object
            Mapper.CreateMap<Comment, Sql.Comment>();
            Sql.Comment c = Mapper.Map<Comment, Sql.Comment>(comment);

            if (comment.CommentId == 0)
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
            comment.CommentId = c.CommentId;
        }

        public void DeleteTicket(int id)
        {
            _ticketsTable.DeleteAllOnSubmit(from t in _ticketsTable
                            where t.TicketId == id
                            select t);
        }

        public void DeleteCategory(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                _categoriesTable.DeleteAllOnSubmit(from t in _categoriesTable
                                            where t.CategoryId == id
                                            select t);

            }
        }

        public void DeleteStatus(int id)
        {
            _statusesTable.DeleteAllOnSubmit(from t in _statusesTable
                                        where t.StatusId == id
                                        select t);
        }

        public void DeleteSeverity(int id)
        {
            _severitiesTable.DeleteAllOnSubmit(from t in _severitiesTable
                                        where t.SeverityId == id
                                        select t);
        }

        public void DeletePriority(int id)
        {
            _prioritiesTable.DeleteAllOnSubmit(from t in _prioritiesTable
                                            where t.PriorityId == id
                                            select t);
        }

        public void DeleteComment(int id)
        {
            _commentsTable.DeleteAllOnSubmit(from c in _commentsTable
                                                 where c.CommentId == id
                                                 select c);
        }
    }
}