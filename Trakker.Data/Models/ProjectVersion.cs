using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class ProjectVersion : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual bool IsReleased { get; set; }
        public virtual int SortOrder { get; set; }


        public virtual Project Project { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }

        public virtual int ClosedTicketCount()
        {
            return Tickets.Where(t => t.IsClosed == true).Count();
        }

        public virtual int OpenTicketCount()
        {
            return Tickets.Where(t => t.IsClosed == false).Count();
        }
    }
}
