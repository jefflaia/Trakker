using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Data
{
    public class Property<T>
    {
        public virtual int Id { get; set; }
        public virtual string Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual T Value { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
