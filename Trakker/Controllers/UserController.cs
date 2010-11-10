using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Trakker.Helpers;
using Trakker.Data;
using Trakker.Data.Services;
using Trakker.ViewData.UserData;
using AutoMapper;
using System.Web.Security;
using Trakker.Attributes;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Collections;
using System.Web.UI.HtmlControls;
using Trakker.Helpers.Table.Controls;
using Trakker.Helpers.Table;


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
            return View(new LoginViewData());
        }

        [HttpPost]
        public ActionResult Login(LoginViewData viewData)
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
        public ActionResult CreateUser(CreateEditUserViewData viewData)
        {
            User existingUser = _userService.GetUserWithEmail(viewData.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
            }

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<CreateEditUserViewData, User>();
                User user = Mapper.Map(viewData, new User());

                _userService.Save(user);
                UnitOfWork.Commit();
            }

            viewData.Roles = _userService.GetAllRoles();

            return View(viewData);
        }

        [Authenticate]
        public ActionResult EditUser(int userId)
        {
            //if (userId == 0) ; //TODO:: redirect

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
            //if (userId == 0) ; //TODO:: redirect

            Mapper.CreateMap<CreateEditUserViewData, User>();
             User user = Mapper.Map(viewData, new User());



            User u = _userService.GetUserWithId(userId);
            //if(u == null); //TODO:: redirect

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
