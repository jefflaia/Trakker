
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using AutoMapper;

namespace Trakker.Data
{
    using Sql = Access.SqlServer;

    public class TicketRepository : ITicketRepository
    {
        protected Sql.TrakkerDBDataContext _db = new Sql.TrakkerDBDataContext();


        public IQueryable<Severity> GetSeverities()
        {
            return from s in _db.Severities
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
            return from p in _db.Priorities
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
            return from t in _db.Categories
                   select new Category
                   {
                       CategoryId = t.CategoryId,
                       Name = t.Name,
                       Description = t.Description
                   };
        }

        public IQueryable<Ticket> GetTickets()
        {
            IUserRepository userRepository = new UserRepository();

            return from t in _db.Tickets
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
            return from s in _db.Status
                   select new Status
                   {
                       StatusId = s.StatusId,
                       Name = s.Name,
                       Description = s.Description
                   };
        }

        public IQueryable<Comment> GetComments()
        {
            return from c in _db.Comments
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
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Ticket, Sql.Ticket>();
                Sql.Ticket t = Mapper.Map<Ticket, Sql.Ticket>(Ticket);

                t.Description = t.Description ?? string.Empty;
                t.Created = t.Created.Equals(DateTime.MinValue) ? DateTime.Now : t.Created;

                
                //check if the Ticket exists
                if (Ticket.TicketId == 0)
                {
                    ctx.Tickets.InsertOnSubmit(t);
                }
                else
                {
                    ctx.Tickets.Attach(t);
                    ctx.Tickets.Context.Refresh(RefreshMode.KeepCurrentValues, t);
                }

                //submit the changes
                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                Ticket.TicketId = t.TicketId;
            };
        }

        public void Save(Category category)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Category, Sql.Category>();
                Sql.Category c = Mapper.Map<Category, Sql.Category>(category);

                if (category.CategoryId == 0)
                {
                    ctx.Categories.InsertOnSubmit(c);
                }
                else
                {
                    ctx.Categories.Attach(c);
                    ctx.Categories.Context.Refresh(RefreshMode.KeepCurrentValues, c);
                }

                //submit the changes
                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                category.CategoryId = c.CategoryId;
            };
        }

        public void Save(Priority priority)
        {

            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Priority, Sql.Priority>();
                Sql.Priority p = Mapper.Map<Priority, Sql.Priority>(priority);

                if (priority.PriorityId == 0)
                {
                    ctx.Priorities.InsertOnSubmit(p);
                }
                else
                {
                    ctx.Priorities.Attach(p);
                    ctx.Priorities.Context.Refresh(RefreshMode.KeepCurrentValues, p);
                }

                //submit the changes
                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                priority.PriorityId = p.PriorityId;

              
            }
        }

        public void Save(Status status)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Status, Sql.Status>();
                Sql.Status s = Mapper.Map<Status, Sql.Status>(status);

                if (status.StatusId == 0)
                {
                    ctx.Status.InsertOnSubmit(s);
                }
                else
                {
                    ctx.Status.Attach(s);
                    ctx.Status.Context.Refresh(RefreshMode.KeepCurrentValues, s);
                }

                //submit the changes
                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                status.StatusId = s.StatusId;
            };
        }

        public void Save(Severity severity)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Severity, Sql.Severity>();
                Sql.Severity s = Mapper.Map<Severity, Sql.Severity>(severity);

                if (severity.SeverityId == 0)
                {
                    ctx.Severities.InsertOnSubmit(s);
                }
                else
                {
                    ctx.Severities.Attach(s);
                    ctx.Severities.Context.Refresh(RefreshMode.KeepCurrentValues, s);
                }

                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                severity.SeverityId = s.SeverityId;
            };
        }

        public void Save(Comment comment)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                //map the priority from our model to the dal object
                Mapper.CreateMap<Comment, Sql.Comment>();
                Sql.Comment c = Mapper.Map<Comment, Sql.Comment>(comment);

                if (comment.CommentId == 0)
                {
                    ctx.Comments.InsertOnSubmit(c);
                }
                else
                {
                    ctx.Comments.Attach(c);
                    ctx.Comments.Context.Refresh(RefreshMode.KeepCurrentValues, c);
                }

                ctx.SubmitChanges();

                //set the id 
                //needed for inserts, updates the id will stay the same
                comment.CommentId = c.CommentId;
            };
        }

        public void DeleteTicket(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Tickets.DeleteAllOnSubmit(from t in ctx.Tickets
                                where t.TicketId == id
                                select t);

                ctx.SubmitChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Categories.DeleteAllOnSubmit(from t in ctx.Categories
                                            where t.CategoryId == id
                                            select t);

                ctx.SubmitChanges();
            }
        }

        public void DeleteStatus(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Status.DeleteAllOnSubmit(from t in ctx.Status
                                            where t.StatusId == id
                                            select t);

                ctx.SubmitChanges();
            }
        }

        public void DeleteSeverity(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Severities.DeleteAllOnSubmit(from t in ctx.Severities
                                            where t.SeverityId == id
                                            select t);

                ctx.SubmitChanges();
            }
        }

        public void DeletePriority(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Priorities.DeleteAllOnSubmit(from t in ctx.Priorities
                                            where t.PriorityId == id
                                            select t);

                ctx.SubmitChanges();
            }
        }

        public void DeleteComment(int id)
        {
            using (Sql.TrakkerDBDataContext ctx = new Sql.TrakkerDBDataContext())
            {
                ctx.Comments.DeleteAllOnSubmit(from c in ctx.Comments
                                                 where c.CommentId == id
                                                 select c);

                ctx.SubmitChanges();
            }
        }


    }
}