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
using Trakker.Infastructure.Streams.Activity.Model;
using Trakker.Infastructure.Streams.Activity;
using Trakker.Areas.Admin.Models;
using NHibernate;
using NHibernate.Criterion;


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

            var activityStream = new UserActivityStream(_userService, _ticketService);



            var model = new UserProfileModel()
            {
                User = user,
                ActivityStreamGroups = activityStream.Generate(15, 0),
                IsOwner = user.Id == Auth.CurrentUser.Id
            };

            return View(model); ;
        }

        [HttpGet]
        public virtual ActionResult ChangePassword(int userId)
        {
            User user = _userService.GetUserWithId(userId);

            if (user == null && user.Id != Auth.CurrentUser.Id )
            {
                PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            return View(new ChangePasswordModel() { 
                User = user
            });
        }

        [HttpPost]
        public virtual ActionResult ChangePassword(int userId, ChangePasswordModel viewModel)
        {
            User user = _userService.GetUserWithId(userId);

            if (user == null)
            {
                return PermanentRedirectToAction(MVC.Error.InvalidAction());
            }

            if (ModelState.IsValid && Auth.PasswordsMatch(viewModel.CurrentPassword, user) == false)
            {
                ModelState.AddModelError("CurrentPassword", "Password incorrect");
            }

            Mapper.CreateMap<ChangePasswordModel, User>();
            Mapper.Map(viewModel, user);

            if (ModelState.IsValid)
            {
                user.Password = Auth.HashPassword(user.Password, user.Salt);
                _userService.Save(user);
                UnitOfWork.Commit();
                return RedirectToAction(MVC.User.UserProfile(userId));
            }

            viewModel.User = _userService.GetUserWithId(userId);

            return View(viewModel);
        }



        public virtual ActionResult Testing()
        {
            IList<User> users = new List<User>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var hqlQuery = session.CreateQuery("from User s");
                users = hqlQuery.List<User>();

            }

            if (users.Count > 0) throw new Exception("working");
         



            throw new NotImplementedException();
            return View();
        }
    }
}
