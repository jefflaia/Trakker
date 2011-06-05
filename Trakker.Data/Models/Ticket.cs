using System;
namespace Trakker.Data
{

    public class Ticket
    {
        public virtual int Id { get; set; }
        public virtual bool IsClosed { get; set; }
        public virtual string Summary { get; set; }
        public virtual int CategoryId { get; set; }
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

    }
}
