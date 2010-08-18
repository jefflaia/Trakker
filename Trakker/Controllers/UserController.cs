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
using Trakker.Attributes;
using System.Data.SqlTypes;

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

        [Authenticate]
        public ActionResult CreateUser()
        {
            return View(new CreateEditUserViewData()
                {
                    Roles = _userService.GetAllRoles()
                });
        }

        [HttpPost]
        [Authenticate]
        public ActionResult CreateUser(User user, string rePassword)
        {
            try
            {
                if (String.Compare(user.Password, rePassword) == 0)
                {
                    user.RoleId = 2;                  
                    _userService.Save(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            return View(new CreateEditUserViewData()
            {
                Roles = _userService.GetAllRoles()
            });
        }

        [Authenticate]
        public ActionResult EditUser(int userId)
        {
            if (userId == 0) ; //TODO:: redirect

            User user = _userService.GetUserWithId(userId);
            
            
            return View(new CreateEditUserViewData()
            {
                Email = user.Email,
                Roles = _userService.GetAllRoles(),
                RoleId = user.RoleId
            });
        }

        [HttpPost]
        [Authenticate]
        public ActionResult EditUser(int userId, CreateEditUserViewData viewData )
        {
            if (userId == 0) ; //TODO:: redirect

            Mapper.CreateMap<CreateEditUserViewData, User>();
            User user = Mapper.Map<CreateEditUserViewData, User>(viewData);



            User u = _userService.GetUserWithId(userId);
            if(u == null); //TODO:: redirect

            try
            {

                _userService.Save(user);
            }
            catch (Exception e)
            {
                //TODO:: rollback
            }


            viewData.Roles = _userService.GetAllRoles();

            return View(viewData);
        }
    
    }
}
