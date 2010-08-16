using System;
using System.Configuration;
using System.Web;
using System.Web.Security;

namespace Trakker.Services
{
    public static class SessionHandler
    {
        const int COOKIE_LIFE = 30;

        public static void CreateCookie(string cookieContent)
        {
            var ticket = new FormsAuthenticationTicket(1, cookieContent, DateTime.Now, DateTime.Now.AddMinutes(30), true, "");

            string cookieContents = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Path = FormsAuthentication.FormsCookiePath
            };

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public static void RemoveCookie()
        {
            string name = FormsAuthentication.FormsCookieName;

            if (HttpContext.Current.Request.Cookies[name] == null) return;

            HttpCookie cookie = new HttpCookie(name) { 
                Expires = DateTime.Now.AddDays(-1D) 
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
            
            //remove the current cookie because we shouldnt be able to get it after calling remove
            HttpContext.Current.Request.Cookies.Remove(name);
        }

        public static string ReadCookie()
        {
            string name = FormsAuthentication.FormsCookieName;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];

            if (cookie != null)
            {
                return FormsAuthentication.Decrypt(cookie.Value).Name;
            }

            return string.Empty;
           
        }
    }
}
