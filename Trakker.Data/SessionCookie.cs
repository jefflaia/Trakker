namespace Trakker.Data
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;

    public static class SessionCookie
    {
        const int COOKIE_LIFE = 480; //8 hours

        public static void Create(string cookieContent)
        {
            var ticket = new FormsAuthenticationTicket(1, cookieContent, DateTime.Now, DateTime.Now.AddMinutes(COOKIE_LIFE), true, "");

            string cookieContents = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                HttpOnly = true,
                Path = FormsAuthentication.FormsCookiePath
            };

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public static void Remove()
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

        public static string Read()
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
