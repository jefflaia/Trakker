namespace Trakker.Data
{
    public class TicketStatus
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsClosedState { get; set; }
    }
}
