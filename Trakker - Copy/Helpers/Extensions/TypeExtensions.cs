using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trakker.Helpers
{
    public static class TypeExtensions
    {
        public static string GetControllerName(this Type controllerType)
        {
            return controllerType.Name.Replace("Controller", string.Empty);
        }
    }
}
