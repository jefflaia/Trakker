using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBase : ScriptableViewComponent
    {

        protected IDatePickerHtmlBuilderFactory _renderFactory;

        private string _format;

        public DatePickerBase(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IDatePickerHtmlBuilderFactory renderFactory, IAssetManager assetManager) :
            base(viewContext, clientSideObjectWriterFactory, assetManager)
        {
            _renderFactory = renderFactory;
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

        public override void WriteInitializationScript(TextWriter writer)
        {
            IClientSideObjectWriter objectWriter = ClientSideObjectWriterFactory.Create(Id, "tDatePicker", writer);

            objectWriter.Start();

            objectWriter.Append("dateFormat", JQueryDatePickerFormatTranslator.Translate(Format));

            objectWriter.AppendClientEvent("onLoad", ClientEvents.OnLoad);
            objectWriter.AppendClientEvent("onChange", ClientEvents.OnChange);
            objectWriter.AppendClientEvent("onOpen", ClientEvents.OnOpen);
            objectWriter.AppendClientEvent("onClose", ClientEvents.OnClose);

            objectWriter.Complete();

            base.WriteInitializationScript(writer);
        }

        protected override void WriteHtml(System.Web.UI.HtmlTextWriter writer)
        {
            IDatePickerBaseHtmlBuilder builder = _renderFactory.Create(this);
            IHtmlNode rootTag = builder.Build();

            rootTag.WriteTo(writer);
            base.WriteHtml(writer);
        }
    }
}
