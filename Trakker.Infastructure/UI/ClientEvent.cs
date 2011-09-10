using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public class ClientEvent
    {
        public Action InlineCode { get; set; }

        public string HandlerName { get; set; }
    }
}
