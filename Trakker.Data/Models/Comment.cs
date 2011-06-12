using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Comment : BaseEntity
    {
        public virtual string Body { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int TicketId { get; set; }
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }        
    }
}
