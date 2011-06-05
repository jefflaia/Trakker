namespace Trakker.Data
{
    public class TicketPriority
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string HexColor { get; set; }
    }
}
