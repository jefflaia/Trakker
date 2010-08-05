using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.ViewData.UserData;
using Trakker.Services;
using AutoMapper;
using System.Web.Security;

namespace Trakker.Controllers
{
    public class UserController : MasterController
    {
       
        protected IUserService _userService;
    
        public UserController()
        {
            _userService = new UserService();

        }
        

        public ActionResult Login()
        {
            return View(new LoginViewData());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
           if(AuthorizationService.ValidateCredentials(user.Email, user.Password))
           {
               AuthorizationService.LogUserIn(user);
               return RedirectToAction<TicketController>(x => x.TicketList(1));
           }

            return View(new LoginViewData()
            {
                Email = user.Email,
                Password = user.Password
            });
        }

        public ActionResult Logout()
        {
            AuthorizationService.LogUserOut();
            AuthorizationService.CurrentUser = null;

            return View(new LogoutViewData());
        }
    }
}
