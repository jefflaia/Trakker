using System;
using System.Collections.Generic;
namespace Trakker.Data
{

    public class Ticket : BaseEntity
    {
        public virtual bool IsClosed { get; set; }
        public virtual string Summary { get; set; }
        public virtual int TypeId { get; set; }
        public virtual int ResolutionId { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual int PriorityId { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string KeyName { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual int AssignedToUserId { get; set; }
        public virtual int CreatedByUserId { get; set; }
        public virtual int AssignedByUserId { get; set; }

        public virtual TicketStatus Status { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual TicketResolution Resolution { get; set; }
        public virtual TicketPriority Priority { get; set; }

        public virtual User AssignedTo { get; set; }
        public virtual User AssignedBy { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual IList<ProjectVersion> FixedOnVersions { get; set; }
        public virtual IList<ProjectVersion> FoundOnVersions { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
