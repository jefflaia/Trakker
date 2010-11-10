using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogin { get; set; }
        public int TotalComments { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public DateTime? LastFailedLoginAttempt { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public bool HasLoggedIn()
        {
            return DateTime.Equals(LastLogin.Value, Created);
        }        
    }
}
