using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.Data.Services;
using AutoMapper;
using Trakker.Attributes;
using System.Web.UI.HtmlControls;
using Trakker.Models;

namespace Trakker.Controllers
{
    [Authenticate]
    public class TicketController : MasterController
    {
       
        public TicketController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }


        #region Tickets
        public ActionResult TicketDetails(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            TicketDetailsModel viewData = new TicketDetailsModel()
            {
                Id = ticket.TicketId,
                Summary = ticket.Summary,
                Description = ticket.Description,
                Created = ticket.Created,
                DueDate = ticket.DueDate,
                Status = _ticketService.GetStatusWithId(ticket.StatusId),
                Priority = _ticketService.GetPriorityWithId(ticket.PriorityId),
                Cateogory = _ticketService.GetCategoryWithId(ticket.CategoryId),
                Resolution = _ticketService.GetResolutionById(ticket.ResolutionId),
                KeyName = ticket.KeyName,
                Comments = _ticketService.GetCommentsWithticketId(ticket.TicketId),
                IsClosed = ticket.IsClosed,
                AssignedBy = _userService.GetUserWithId(ticket.AssignedByUserId),
                CreatedBy = _userService.GetUserWithId(ticket.CreatedByUserId),
                AssignedTo = _userService.GetUserWithId(ticket.AssignedToUserId)
            };
         
            return View(viewData);
        }

        public ActionResult BrowseTickets(int? index)
        {
            const int PAGE_SIZE = 10;
            User user;

            IDictionary<int, TicketPriority> priorities = new Dictionary<int, TicketPriority>();
            IDictionary<int, TicketStatus> status = new Dictionary<int, TicketStatus>();
            IDictionary<int, TicketType> categories = new Dictionary<int, TicketType>();
            IDictionary<int, User> users = new Dictionary<int, User>();

            foreach (var p in _ticketService.GetAllPriorities()) priorities.Add(p.Id, p);
            foreach (var s in _ticketService.GetAllStatus())status.Add(s.Id, s);        
            foreach (var c in _ticketService.GetAllCategories()) categories.Add(c.Id, c);

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
            
            BrowseTicketsModel viewData = new BrowseTicketsModel()
            {
                Items = tickets,
                Users = users,
                Priorities = priorities,
                Categories = categories,
                Status = status,
                TotalTickets = _ticketService.TotalTickets(),
                Page = index ?? 1,
                PageSize = PAGE_SIZE
            };

            return View(viewData);
        }


        public ActionResult CreateTicket()
        {
            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Categories = _ticketService.GetAllCategories(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Users = _userService.GetAllUsers(),
                Projects = _projectService.GetAllProjects(),
                Resolutions = _ticketService.GetAllResolutions()
            };

            if (IsProjectSelected())
            {
                viewData.ProjectId = CurrentProject.ProjectId;
            }
            
            return View(viewData);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateTicket(CreateEditTicketModel viewData)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTicketModel, Ticket>();
                Ticket ticket = Mapper.Map(viewData, new Ticket());

                ticket.CreatedByUserId = Auth.CurrentUser.UserId;
                ticket.AssignedByUserId = Auth.CurrentUser.UserId;
                ticket.Created = DateTime.Now;

                _ticketService.Save(ticket);
                UnitOfWork.Commit();

                return RedirectToRoute("BrowseTickets");
            }

            viewData.Categories = _ticketService.GetAllCategories();
            viewData.Priorities = _ticketService.GetAllPriorities();
            viewData.Status = _ticketService.GetAllStatus();
            viewData.Users = _userService.GetAllUsers();
            viewData.Projects = _projectService.GetAllProjects();
            viewData.Resolutions = _ticketService.GetAllResolutions();

            return View(viewData);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditTicket(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null) throw new Exception("redirect, ticket doesnt exist!");

            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Projects = _projectService.GetAllProjects(),
                Categories = _ticketService.GetAllCategories(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Users = _userService.GetAllUsers(),
                Resolutions = _ticketService.GetAllResolutions()
            };

            Mapper.CreateMap<Ticket, CreateEditTicketModel>();
            viewData = Mapper.Map(ticket, viewData);

            return View(viewData);
        }
         
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditTicket(string keyName, CreateEditTicketModel viewData)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null) throw new Exception("redirect, ticket doesnt exist!");

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTicketModel, Ticket>();
                ticket = Mapper.Map(viewData, ticket);

                _ticketService.Save(ticket);
                UnitOfWork.Commit();

                return RedirectToAction<TicketController>(x => x.TicketDetails(ticket.KeyName));
            }

            viewData.Categories = _ticketService.GetAllCategories();
            viewData.Priorities = _ticketService.GetAllPriorities();
            viewData.Status = _ticketService.GetAllStatus();
            viewData.Users = _userService.GetAllUsers();
            viewData.Projects = _projectService.GetAllProjects();
            viewData.Resolutions = _ticketService.GetAllResolutions();

            return View(viewData);
        }

        #endregion

        #region Comment

        public ActionResult CreateComment(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if(ticket == null)
                throw new Exception("need a redirect here! the ticket does not exist");

            return View(new CommentCreateEditModel());
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

            CommentCreateEditModel viewData = new CommentCreateEditModel()
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

            CommentCreateEditModel viewData = new CommentCreateEditModel()
            {
                Comment = comment
            };

            return View(viewData);
        }

        public ActionResult Comment(Comment comment)
        {
            CommentModel viewData = Mapper.Map<Comment, CommentModel>(comment);

            return PartialView(viewData);
        }
        #endregion

        
    }
}
