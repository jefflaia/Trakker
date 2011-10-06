using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public enum FileUsage
    {
        ProjectAvatar = 1,
        UserAvatar = 2,
        TicketAttachment = 3
    };


    public class File : BaseEntity
    {
        public virtual string FileName { get; set; }
        public virtual string Path { get; set; }
        public virtual string ContentType { get; set; }
        public virtual DateTime Uploaded { get; set; }
        public virtual Int64 ContentLength { get; set; }
        public virtual FileUsage Usage { get; set; }
    }
}
