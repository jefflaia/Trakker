using System;
namespace Trakker.Data
{
    public class Component
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Description { get; set; }
        public virtual int TicketId { get; set; }
        public virtual int ProjectId { get; set; }
    }
}
