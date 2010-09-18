using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.ViewData.TicketData;
using Trakker.Services;
using AutoMapper;
using Trakker.Attributes;
using System.Web.UI.HtmlControls;

namespace Trakker.Controllers
{
    [Authenticate]
    public class TicketController : MasterController
    {
       
        public TicketController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
            _ticketService = ticketService;
            _userService = userService;

        }


        #region MainActionResults
        public ActionResult TicketDetails(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            IList<WidgetAction> comments = new List<WidgetAction>();

            foreach (Comment comment in _ticketService.GetCommentsWithticketId(ticket.TicketId))
            {
                comments.Add(new WidgetAction("Comment", "ticket", comment));
            }

            TicketDetailsViewData viewData = new TicketDetailsViewData()
            {
                Id = ticket.TicketId,
                Summary = ticket.Summary,
                Description = ticket.Description,
                Created = ticket.Created,
                DueDate = ticket.DueDate,
                Status = _ticketService.GetStatusWithId(ticket.StatusId),
                Priority = _ticketService.GetPriorityWithId(ticket.PriorityId),
                Severity = _ticketService.GetSeverityWithId(ticket.SeverityId),
                Cateogory = _ticketService.GetCategoryWithId(ticket.CategoryId),
                KeyName = ticket.KeyName,
                Comments = comments,
                AssignedBy = _userService.GetUserWithId(ticket.AssignedByUserId),
                CreatedBy = _userService.GetUserWithId(ticket.CreatedByUserId),
                AssignedTo = _userService.GetUserWithId(ticket.AssignedToUserId)
            };
         
            return View(viewData);
        }

        [Authenticate]
        public ActionResult TicketList(int? index)
        {
            const int PAGE_SIZE = 10;
            User user;

            IDictionary<int, Priority> priorities = new Dictionary<int, Priority>();
            IDictionary<int, Status> status = new Dictionary<int, Status>();
            IDictionary<int, Category> categories = new Dictionary<int, Category>();
            IDictionary<int, Severity> severities = new Dictionary<int, Severity>();
            IDictionary<int, User> users = new Dictionary<int, User>();

            foreach (var p in _ticketService.GetAllPriorities()) priorities.Add(p.PriorityId, p);
            foreach (var s in _ticketService.GetAllStatus())status.Add(s.StatusId, s);        
            foreach (var c in _ticketService.GetAllCategories()) categories.Add(c.CategoryId, c);
            foreach (var s in _ticketService.GetAllSeverities()) severities.Add(s.SeverityId, s);

            IList<Ticket> tickets = _ticketService.TicketList(PAGE_SIZE, index ?? 1);
            foreach (Ticket ticket in tickets)
            {
                if (users.ContainsKey(ticket.AssignedToUserId) == false)
                {
                    user = _userService.GetUserWithId(ticket.AssignedToUserId);
                    users.Add(user.UserId, user);
                }

                if (users.ContainsKey(ticket.AssignedByUserId) == false)
                {
                    user = _userService.GetUserWithId(ticket.AssignedByUserId);
                    users.Add(user.UserId, user);
                }

                if (users.ContainsKey(ticket.CreatedByUserId) == false)
                {
                    user = _userService.GetUserWithId(ticket.CreatedByUserId);
                    users.Add(user.UserId, user);
                }
            }
            
            TicketListViewData viewData = new TicketListViewData()
            {
                Items = tickets,
                Users = users,
                Priorities = priorities,
                Severities = severities,
                Categories = categories,
                Status = status,
                Pagination = new WidgetAction("ticketListPagination", "Nav", new
                { 
                    pageIndex = index ?? 1,
                    totalItemCount = _ticketService.TotalTickets(),
                    pageSize = PAGE_SIZE
                })
            };


            return View(viewData);
        }


        public ActionResult CreateTicket()
        {
            CreateEditViewData viewData = new CreateEditViewData()
            {
                Ticket = new Ticket()
                {
                    DueDate = DateTime.Today
                },
                Categories = _ticketService.GetAllCategories(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Severities = _ticketService.GetAllSeverities(),
                Users = _userService.GetAllUsers()
            };

            viewData.Users.Insert(0, new User()); //add a blank selection

            return View(viewData);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateTicket(Ticket ticket)
        {
            try
            {
                ticket.ProjectId = ProjectService.SelectedProjectId;
                ticket.CreatedByUserId = _userService.CurrentUser.UserId;
                ticket.AssignedByUserId = _userService.CurrentUser.UserId;
                ticket.AssignedToUserId = _userService.CurrentUser.UserId;
               
                _ticketService.Save(ticket);

                return RedirectToAction<TicketController>(x => x.TicketList(1));
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditTicket(string keyName)
        {
            
            CreateEditViewData viewData = new CreateEditViewData()
            {
                Categories = _ticketService.GetAllCategories(),
                Severities = _ticketService.GetAllSeverities(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Ticket = _ticketService.GetTicketWithKeyName(keyName),
                Users = _userService.GetAllUsers()
            };
            
            viewData.Users.Insert(0, new User()); //add a blank selection

            return View(viewData);
        }
         
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditTicket(string keyName, Ticket ticket)
        {
            Ticket t = _ticketService.GetTicketWithKeyName(keyName);

            if (t == null) throw new Exception("redirect, ticket doesnt exist!");

            try
            {
                ticket.TicketId = t.TicketId;
                ticket.Created = t.Created;


                _ticketService.Save(ticket);
                return RedirectToAction<TicketController>(x => x.TicketDetails(ticket.KeyName));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            
        }

        public ActionResult CreateComment(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if(ticket == null)
                throw new Exception("need a redirect here! the ticket does not exist");

            return View(new CommentCreateEditViewData());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateComment(string keyName, Comment comment)
        {

            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);
            
            if (ticket == null)
                throw new Exception("need a redirect here! the ticket does not exist");
                        
            try
            {
                comment.Created = DateTime.Today;
                comment.Modified = DateTime.Today;
                comment.UserId = 1;
                comment.TicketId = ticket.TicketId;
                _ticketService.Save(comment);

                return RedirectToAction<TicketController>(x => x.TicketDetails(keyName));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult EditComment(string keyName, int id)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);
            Comment comment = _ticketService.GetCommentWithId(id);

            if (ticket == null) throw new Exception("redirect, ticket does not exist");
            if (comment == null) throw new Exception("redirect, comment does not exist");

            if (comment.TicketId != ticket.TicketId) throw new Exception("redirect, comment does not belong to this ticket");
            if (comment.UserId != 1) throw new Exception("redirect comment does not belong to this user");

            CommentCreateEditViewData viewData = new CommentCreateEditViewData()
            {
                Comment = comment
            };

            return View(viewData);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditComment(string keyName, int id, Comment comment)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);
            Comment originalComment = _ticketService.GetCommentWithId(id);

            if (ticket == null) throw new Exception("redirect, ticket does not exist");
            if (ticket == null) throw new Exception("redirect, comment does not exist");

            if (originalComment.TicketId != ticket.TicketId) throw new Exception("redirect, comment does not belong to this ticket");
            if (originalComment.UserId != 1) throw new Exception("redirect comment does not belong to this user");

            try
            {
                originalComment.Body = comment.Body;
                originalComment.Modified = DateTime.Now;
                _ticketService.Save(originalComment);
            }
            catch (Exception e)
            {
                throw new Exception();
            }

            CommentCreateEditViewData viewData = new CommentCreateEditViewData()
            {
                Comment = comment
            };

            return View(viewData);
        }

        #endregion

        #region Widgets

        public ActionResult Comment(Comment comment)
        {
            CommentViewData viewData = Mapper.Map<Comment, CommentViewData>(comment);

            return PartialView(viewData);
        }
        #endregion
    }
}
