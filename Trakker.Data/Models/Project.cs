using System;
namespace Trakker.Data
{
    public class Project : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual int Lead { get; set; }
        public virtual string KeyName { get; set; }
        public virtual DateTime? Due { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual int TicketIndex { get; set; }
        public virtual string Url { get; set; }
        public virtual int ColorPaletteId { get; set; }
        public virtual int AvatarId { get; set; }

        public virtual ColorPalette ColorPalette { get; set; }
        public virtual File Avatar { get; set; }
    }
}
