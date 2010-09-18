using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Helpers.Table.Controls
{
    public abstract class TableControl
    {
        public object Value { get; set; }
        public abstract string FormatCell();
    }
}
