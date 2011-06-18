using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class User : BaseEntity
    {
        #region Properties
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? LastLogin { get; set; }
        public virtual int TotalComments { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual DateTime? LastFailedLoginAttempt { get; set; }
        public virtual int RoleId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Role Role { get; set; }
        #endregion

        #region Helpers
        public virtual string FullName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public virtual bool HasLoggedIn()
        {
            return DateTime.Equals(LastLogin.Value, Created);
        }
        #endregion
    }
}
