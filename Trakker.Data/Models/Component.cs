using System;
namespace Trakker.Data
{
    public class Component : NamedEntity
    {
        public virtual DateTime Created { get; set; }
        public virtual int TicketId { get; set; }
        public virtual int ProjectId { get; set; }
    }
}
