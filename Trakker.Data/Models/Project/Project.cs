using System;
namespace Trakker.Data
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Lead { get; set; }
        public string KeyName { get; set; }
        public DateTime? Due { get; set;}
        public DateTime? Created { get; set; }
        public int TicketIndex { get; set; }
    }
}
