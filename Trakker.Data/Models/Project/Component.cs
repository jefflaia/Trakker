using System;
namespace Trakker.Data
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string Name{ get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int TicketId { get; set; }
        public int ProjectId { get; set; }
    }
}
