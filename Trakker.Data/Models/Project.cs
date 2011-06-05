using System;
namespace Trakker.Data
{
    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Lead { get; set; }
        public virtual string KeyName { get; set; }
        public virtual DateTime? Due { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual int TicketIndex { get; set; }
        public virtual string Url { get; set; }
    }
}
