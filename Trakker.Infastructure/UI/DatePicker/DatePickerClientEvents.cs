using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public class DatePickerClientEvents
    {
        public DatePickerClientEvents()
        {
            OnLoad = new ClientEvent();
            OnChange = new ClientEvent();
            OnOpen = new ClientEvent();
            OnClose = new ClientEvent();
        }

        public ClientEvent OnLoad { get; private set; }

        public ClientEvent OnChange { get; private set; }

        public ClientEvent OnOpen { get; private set; }

        public ClientEvent OnClose { get; private set; }
    }
}
