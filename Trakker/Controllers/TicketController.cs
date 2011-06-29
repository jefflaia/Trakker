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
        public TicketController(ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
            : base(ticketService, userRepo, projectRepo, ticketRepo)
        {
        }

        #region Tickets
        public virtual ActionResult TicketDetails(string keyName)
        {
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);
            ticket.AssignedBy = _userRepo.GetUserById(ticket.AssignedByUserId);
            ticket.CreatedBy = _userRepo.GetUserById(ticket.CreatedByUserId);
            ticket.AssignedTo = _userRepo.GetUserById(ticket.AssignedToUserId);

            var comments = _ticketRepo.GetCommentsByTicket(ticket);
            foreach (var comment in comments)
            {
                comment.User = _userRepo.GetUserById(comment.UserId);
            }
            
            var activityStream = new TicketActivityStream(_userRepo, _ticketRepo);
            activityStream.Ticket = ticket;

            TicketDetailsModel viewData = new TicketDetailsModel()
            {
                Ticket = ticket,
                Comments = comments,
                ActivityGroups = activityStream.Generate(15, 0)
            };
         
            return View(viewData);
        }

        public virtual ActionResult BrowseTickets(int? index)
        {
            const int PAGE_SIZE = 10;
            User user;
            Paginated<Ticket> tickets;
            
            IDictionary<int, TicketPriority> priorities = _ticketRepo.GetPriorities().ToDictionary(m => m.Id);
            IDictionary<int, TicketStatus> status = _ticketRepo.GetStatus().ToDictionary(m => m.Id);
            IDictionary<int, TicketType> types = _ticketRepo.GetTypes().ToDictionary(m => m.Id);
            IDictionary<int, User> users = new Dictionary<int, User>();

            if (CurrentProject != null)
            {
                tickets = _ticketRepo.GetTicketsByProject(CurrentProject, index ?? 1, PAGE_SIZE);
            }
            else
            {
                tickets = _ticketRepo.GetTickets(index ?? 1, PAGE_SIZE);
            }
            
            foreach (Ticket ticket in tickets.Items)
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
                Items = tickets.Items,
                Users = users,
                Priorities = priorities,
                Categories = types,
                Status = status,
                TotalTickets = tickets.TotalItems,
                Page = index ?? 1,
                PageSize = PAGE_SIZE
            };

            return View(viewData);
        }


        public virtual ActionResult CreateTicket()
        {
            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Categories = _ticketRepo.GetTypes(),
                Priorities = _ticketRepo.GetPriorities(),
                Status = _ticketRepo.GetStatus(),
                Users = _userRepo.GetUsers(),
                Projects = _projectRepo.GetProjects(),
                Resolutions = _ticketRepo.GetResolutions()
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
                ticket.KeyName = _ticketService.GenerateTicketKey(CurrentProject);

                _ticketService.AddTicketToProject(ticket, CurrentProject);
                

                return RedirectToRoute("BrowseTickets");
            }

            viewData.Categories = _ticketRepo.GetTypes();
            viewData.Priorities = _ticketRepo.GetPriorities();
            viewData.Status = _ticketRepo.GetStatus();
            viewData.Users = _userRepo.GetUsers();
            viewData.Projects = _projectRepo.GetProjects();
            viewData.Resolutions = _ticketRepo.GetResolutions();

            return View(viewData);
        }

        [HttpGet]
        public virtual ActionResult EditTicket(string keyName)
        {
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.TicketNotFound());
            }

            CreateEditTicketModel viewData = new CreateEditTicketModel()
            {
                Projects = _projectRepo.GetProjects(),
                Categories = _ticketRepo.GetTypes(),
                Priorities = _ticketRepo.GetPriorities(),
                Status = _ticketRepo.GetStatus(),
                Users = _userRepo.GetUsers(),
                Resolutions = _ticketRepo.GetResolutions()
            };

            Mapper.CreateMap<Ticket, CreateEditTicketModel>();
            viewData = Mapper.Map(ticket, viewData);

            return View(viewData);
        }
         
        [HttpPost]
        public virtual ActionResult EditTicket(string keyName, CreateEditTicketModel viewData)
        {
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.TicketNotFound());
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditTicketModel, Ticket>();
                ticket = Mapper.Map(viewData, ticket);

                _ticketRepo.Save(ticket);
                

                return RedirectToRoute(MVC.Ticket.TicketDetails(keyName));
            }

            viewData.Categories = _ticketRepo.GetTypes();
            viewData.Priorities = _ticketRepo.GetPriorities();
            viewData.Status = _ticketRepo.GetStatus();
            viewData.Users = _userRepo.GetUsers();
            viewData.Projects = _projectRepo.GetProjects();
            viewData.Resolutions = _ticketRepo.GetResolutions();

            return View(viewData);
        }

        #endregion

        #region Comment

        public virtual ActionResult CreateComment(string keyName)
        {
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);

            if (ticket == null)
            {
                return RedirectToAction(MVC.Error.InvalidAction());
            }

            return View(new CommentCreateEditModel());
        }

        [HttpPost]
        public virtual ActionResult CreateComment(string keyName, Comment comment)
        {
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);

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
                _ticketRepo.Save(comment);
                

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
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);
            Comment comment = _ticketRepo.GetCommentById(id);

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
            Ticket ticket = _ticketRepo.GetTicketByKey(keyName);
            Comment originalComment = _ticketRepo.GetCommentById(id);

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
                _ticketRepo.Save(originalComment);

                
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
