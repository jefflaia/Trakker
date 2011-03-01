using System;
namespace Trakker.Data
{

    public class Ticket
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public int ResolutionId { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DueDate { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public string KeyName { get; set; }
        public int ProjectId { get; set; }
        public int AssignedToUserId { get; set; }
        public int CreatedByUserId { get; set; }
        public int AssignedByUserId { get; set; }
		public TicketStatus Status { get; set; }

    }
}
