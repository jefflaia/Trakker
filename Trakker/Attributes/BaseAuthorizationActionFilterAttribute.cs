using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trakker.Data.Services;
using Trakker.IoC;

namespace Trakker.Attributes
{
    public class BaseAuthorizationActionFilterAttribute : ActionFilterAttribute
    {
        public IUserService _userService;

        public BaseAuthorizationActionFilterAttribute()
        {
            _userService = WindsorContainerProvider.Resolve<IUserService>();
        }
    }
}