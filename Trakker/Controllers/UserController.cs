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
    public class UserController : MasterController
    {
       public UserController(IUserService userService, ITicketService ticketService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {            
        }
        

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel viewData)
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
                    
                    return RedirectToAction<TicketController>(x => x.TicketList(1));
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

        public ActionResult Logout()
        {
            Auth.LogUserOut();
            Auth.CurrentUser = null;

            return View(new LogoutModel());
        }

        
    
    }
}
