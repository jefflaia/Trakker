using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.Data.Services;
using AutoMapper;
using Trakker.Attributes;
using System.Web.UI.HtmlControls;
using Trakker.Models;
using Trakker.Infastructure.Streams.Activity;
using Trakker.Data.Repositories;

namespace Trakker.Controllers
{
    [Authenticate]
    public partial class TicketController : MasterController
    {
        public TicketController(ITicketService ticketService, IUserService userService, IProjectService projectService, IUserRepository userRepo)
            : base(projectService, ticketService, userService, userRepo)
        {
        }

        #region Tickets
        public virtual ActionResult TicketDetails(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            var comments = _ticketService.GetCommentsWithticketId(ticket.Id);
            var users = new Dictionary<int, User>();
            
            //avoid querying for the same user more than once
            foreach (var comment in comments)
            {
                if (users.ContainsKey(comment.UserId))
                {
                    comment.User = users[comment.UserId];
                }
                else
                {
                    users.Add(comment.UserId, _userRepo.GetUserById(comment.UserId));
                    comment.User = users[comment.UserId];
                }
            }

            var activityStream = new TicketActivityStream(_userService, _ticketService);
            activityStream.Ticket = ticket;

            TicketDetailsModel viewData = new TicketDetailsModel()
            {
                Id = ticket.Id,
                Summary = ticket.Summary,
                Description = ticket.Description,
                Created = ticket.Created,
                DueDate = ticket.DueDate,
                Status = _ticketService.GetStatusWithId(ticket.StatusId),
                Priority = _ticketService.GetPriorityById(ticket.PriorityId),
                Cateogory = _ticketService.GetTypeById(ticket.CategoryId),
                Resolution = _ticketService.GetResolutionById(ticket.ResolutionId),
                KeyName = ticket.KeyName,
                Comments = comments,
                IsClosed = ticket.IsClosed,
                AssignedBy = _userRepo.GetUserById(ticket.AssignedByUserId),
                CreatedBy = _userRepo.GetUserById(ticket.CreatedByUserId),
                AssignedTo = _userRepo.GetUserById(ticket.AssignedToUserId),
                ActivityGroups = activityStream.Generate(15, 0)
            };
         
            return View(viewData);
        }

        public virtual ActionResult BrowseTickets(int? index)
        {
            const int PAGE_SIZE = 10;
            User user;


            IDictionary<int, TicketPriority> priorities = _ticketService.GetAllPriorities().ToDictionary(m => m.Id);
            IDictionary<int, TicketStatus> status = _ticketService.GetAllStatus().ToDictionary(m => m.Id);
            IDictionary<int, TicketType> types = _ticketService.GetAllTypes().ToDictionary(m => m.Id);
            IDictionary<int, User> users = new Dictionary<int, User>();


            IList<Ticket> tickets = _ticketService.TicketList(PAGE_SIZE, index ?? 1);
            foreach (Ticket ticket in tickets)
            {
                if (users.ContainsKey(ticket.AssignedToUserId) == false)
                {
                    user = _userRepo.GetUserById(ticket.AssignedToUserId);
                    users.Add(user.Id, user);
                }

                if (users.ContainsKey(ticket.AssignedByUserId) == false)
                {
                    user = _userRepo.GetUserById(ticket.AssignedByUserId);
                    users.Add(user.Id, user);
                }

                if (users.ContainsKey(ticket.CreatedByUserId) == false)
                {
                    user = _userRepo.GetUserById(ticket.CreatedByUserId);
                    users.Add(user.Id, user);
                }
            }
            
            BrowseTicketsModel viewData = new BrowseTicketsModel()
            {
                Items = tickets,
                Users = users,
                Priorities = priorities,
                Categories = types,
                Status = status,
                TotalTickets = _ticketService.TotalTickets(),
                Page = index ?? 1,
                PageSize = PAGE_SIZE
            };

            return View(viewData);
        }


        public virtual ActionResult CreateTicket()
        {
            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Categories = _ticketService.GetAllTypes(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Users = _userService.GetAllUsers(),
                Projects = _projectService.GetAllProjects(),
                Resolutions = _ticketService.GetAllResolutions()
            };

            if (IsProjectSelected())
            {
                viewData.ProjectId = CurrentProject.Id;
            }
            
            return View(viewData);
        }

        [HttpPost]
        public virtual ActionResult CreateTicket(CreateEditTicketModel viewData)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTicketModel, Ticket>();
                Ticket ticket = Mapper.Map(viewData, new Ticket());

                ticket.CreatedByUserId = Auth.CurrentUser.Id;
                ticket.AssignedByUserId = Auth.CurrentUser.Id;
                ticket.Created = DateTime.Now;

                _ticketService.Save(ticket);
                UnitOfWork.Commit();

                return RedirectToRoute("BrowseTickets");
            }

            viewData.Categories = _ticketService.GetAllTypes();
            viewData.Priorities = _ticketService.GetAllPriorities();
            viewData.Status = _ticketService.GetAllStatus();
            viewData.Users = _userService.GetAllUsers();
            viewData.Projects = _projectService.GetAllProjects();
            viewData.Resolutions = _ticketService.GetAllResolutions();

            return View(viewData);
        }

        [HttpGet]
        public virtual ActionResult EditTicket(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.TicketNotFound());
            }

            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Projects = _projectService.GetAllProjects(),
                Categories = _ticketService.GetAllTypes(),
                Priorities = _ticketService.GetAllPriorities(),
                Status = _ticketService.GetAllStatus(),
                Users = _userService.GetAllUsers(),
                Resolutions = _ticketService.GetAllResolutions()
            };

            Mapper.CreateMap<Ticket, CreateEditTicketModel>();
            viewData = Mapper.Map(ticket, viewData);

            return View(viewData);
        }
         
        [HttpPost]
        public virtual ActionResult EditTicket(string keyName, CreateEditTicketModel viewData)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.TicketNotFound());
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTicketModel, Ticket>();
                ticket = Mapper.Map(viewData, ticket);

                _ticketService.Save(ticket);
                UnitOfWork.Commit();

                return RedirectToRoute(MVC.Ticket.TicketDetails(keyName));
            }

            viewData.Categories = _ticketService.GetAllTypes();
            viewData.Priorities = _ticketService.GetAllPriorities();
            viewData.Status = _ticketService.GetAllStatus();
            viewData.Users = _userService.GetAllUsers();
            viewData.Projects = _projectService.GetAllProjects();
            viewData.Resolutions = _ticketService.GetAllResolutions();

            return View(viewData);
        }

        #endregion

        #region Comment

        public virtual ActionResult CreateComment(string keyName)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.InvalidAction());
            }

            return View(new CommentCreateEditModel());
        }

        [HttpPost]
        public virtual ActionResult CreateComment(string keyName, Comment comment)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.InvalidAction());
            }
                        
            if (ModelState.IsValid)
            {
                comment.Created = DateTime.Now;
                comment.Modified = DateTime.Now;
                comment.UserId = Auth.CurrentUser.Id;
                comment.TicketId = ticket.Id;
                _ticketService.Save(comment);
                UnitOfWork.Commit();

                return RedirectToAction(MVC.Ticket.TicketDetails(keyName));
            }

            CommentCreateEditModel viewData = new CommentCreateEditModel()
            {
                Comment = comment
            };

            return View(viewData);
        }

        public virtual ActionResult EditComment(string keyName, int id)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);
            Comment comment = _ticketService.GetCommentWithId(id);

            if (ticket == null ||
                comment == null ||
                comment.TicketId != ticket.Id ||
                comment.UserId != 1)
            {
                return RedirectToAction(MVC.Error.InvalidAction());
            }

            CommentCreateEditModel viewData = new CommentCreateEditModel()
            {
                Comment = comment
            };

            return View(viewData);
        }

        [HttpPost]
        public virtual ActionResult EditComment(string keyName, int id, Comment comment)
        {
            Ticket ticket = _ticketService.GetTicketWithKeyName(keyName);
            Comment originalComment = _ticketService.GetCommentWithId(id);

            if (ticket == null || 
                originalComment == null ||
                originalComment.TicketId != ticket.Id ||
                originalComment.UserId != 1)
            {
                return RedirectToAction(MVC.Error.InvalidAction());
            }

            if (ModelState.IsValid)
            {
                originalComment.Body = comment.Body;
                originalComment.Modified = DateTime.Now;
                _ticketService.Save(originalComment);

                UnitOfWork.Commit();
                return RedirectToAction(MVC.Ticket.TicketDetails(keyName));
            }

            return View(new CommentCreateEditModel()
            {
                Comment = comment
            });
        }

        #endregion
        
    }
}
