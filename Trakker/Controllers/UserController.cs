using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.Data.Services;
using AutoMapper;
using System.Web.Security;
using Trakker.Attributes;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Collections;
using System.Web.UI.HtmlControls;
using Trakker.Helpers.Table.Controls;
using Trakker.Helpers.Table;
using Trakker.Models;


namespace Trakker.Controllers
{
    public partial class UserController : MasterController
    {
       public UserController(IUserService userService, ITicketService ticketService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {            
        }
        
        public virtual ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public virtual ActionResult Login(LoginModel viewData)
        {
            if (ModelState.IsValid)
            {
                if (Auth.ValidateCredentials(viewData.Email, viewData.Password))
                {
                    User user = _userService.GetUserWithEmail(viewData.Email);
                    user.LastLogin = DateTime.Now;
                    _userService.Save(user);
                    UnitOfWork.Commit();

                    Auth.LogUserIn(user);

                    return RedirectToAction(MVC.Ticket.BrowseTickets());
                }
                else
                {
                    ModelState.AddModelError("Invalid", "Invalid email or password");
                    User user = _userService.GetUserWithEmail(viewData.Email);

                    if (user != null)
                    {
                        user.FailedPasswordAttemptCount++;
                        user.LastFailedLoginAttempt = DateTime.Now;
                        _userService.Save(user);
                        UnitOfWork.Commit();
                    }
                }
            }

            return View(viewData);
        }

        public virtual ActionResult Logout()
        {
            Auth.LogUserOut();
            Auth.CurrentUser = null;

            return View(new LogoutModel());
        }

        public virtual ActionResult UserProfile(int userId)
        {
            var user = _userService.GetUserWithId(userId);

            if (user == null)
            {
                Response.StatusCode = 404;
                Response.RedirectLocation = "/user-not-found";

                return PermanentRedirectToAction(MVC.Error.UserNotFound());

               
            }

            var model = new UserProfileModel()
            {
                User = user
            };

            return View(model); ;
        }    
    }
}
