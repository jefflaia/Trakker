using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Trakker.Data
{
    public static class ProjectCookie
    {
        const string CURRENT_PROJECT_COOKIE_NAME = "Project";
        
        public static int Read()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(CURRENT_PROJECT_COOKIE_NAME);

            if (cookie != null)
            {
                int projectId;
                bool success = Int32.TryParse(cookie.Value, out projectId);

                if (success)
                {
                    return projectId;
                }
            }

            return 0;
        }

        public static void Create(int projectId)
        {
            HttpCookie cookie = new HttpCookie(CURRENT_PROJECT_COOKIE_NAME)
            {
                Value = projectId.ToString()
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void Remove()
        {
            HttpContext.Current.Response.Cookies.Remove(CURRENT_PROJECT_COOKIE_NAME);
        }
    }
}
