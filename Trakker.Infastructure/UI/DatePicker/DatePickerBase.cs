using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBase : ScriptedViewComponent
    {

        private string _format;

        public DatePickerBase(IAssetManager assetManager) :
            base(assetManager)
        {
            ClientEvents = new DatePickerClientEvents();
            Format = "MM/dd/yyyy";
        }

        public DatePickerClientEvents ClientEvents { get; set; }

        public DateTime? Value 
        { 
            get; 
            set; 
        }

        public string Format
        {
            get;
            set;
        }

    }
}
