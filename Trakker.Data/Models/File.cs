using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class File : BaseEntity
    {
        public virtual string FileName { get; set; }
        public virtual string Path { get; set; }
        public virtual string ContentType { get; set; }
        public virtual DateTime Uploaded { get; set; }
        public virtual Int64 ContentLength { get; set; }

    }
}
