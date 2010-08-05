using System;
namespace Trakker.Data
{

    public class Ticket
    {
        public int TicketId { get; set; }

        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public int SeverityId { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string Slug { get; set; }
        public int ProjectId { get; set; }
        public int AssignedTo { get; set; }
        public int CreatedBy { get; set; }
        public int AssignedBy { get; set; }
    }
}
