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
           // var test = uR.GetById(1);

            _userService = userService;
            
        }
        

        public ActionResult Login()
        {
            var t  = new HtmlTable();
            var td = new HtmlTableCell();
            
            IList<User> c = _userService.GetAllUsers();

            var table = new TestTable(c);

            var control = table.CreateColumn<DateFormatControl>("UserId")
                .SetHeaderText("Yeah user baby");
            

           table.GetColumn(x=>x.Created).SetControl(new DateFormatControl());
           table.GetColumn(x => x.UserId).Ignore = true;
             

            var viewData = new LoginViewData()
                {
                    Table = table
                };

            return View(viewData);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (_userService.ValidateCredentials(user.Email, user.Password))
           {
               _userService.LogUserIn(user);
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
            _userService.LogUserOut();
            _userService.CurrentUser = null;

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
