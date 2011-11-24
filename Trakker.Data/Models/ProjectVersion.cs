using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class ProjectVersion : BaseEntity
    {
        public ProjectVersion()
        {
            FixedTickets = new List<Ticket>();
            FoundTickets = new List<Ticket>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual bool IsReleased { get; set; }
        public virtual int SortOrder { get; set; }


        public virtual Project Project { get; set; }
        public virtual IList<Ticket> FixedTickets { get; set; }
        public virtual IList<Ticket> FoundTickets { get; set; }

        public virtual IList<Ticket> ClosedFixedTickets
        {
            get
            {
                return FixedTickets.Where(t => t.IsClosed == true).ToList();
            }
        }

        public virtual IList<Ticket> OpenFixedTickets
        {
            get
            {
                return FixedTickets.Where(t => t.IsClosed == false).ToList();
            }
        }

        public virtual double FixedPercentClosed()
        {
            double total = Convert.ToDouble(FixedTickets.Count > 0 ? FixedTickets.Count : 1);
            double count = Convert.ToDouble(this.ClosedFixedTickets.Count);

            return ((count / total) * 100);
        }
    }
}
