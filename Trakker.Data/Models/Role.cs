using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Role : NamedEntity
    {
        public virtual IList<User> Users { get; set; }
    }
}
