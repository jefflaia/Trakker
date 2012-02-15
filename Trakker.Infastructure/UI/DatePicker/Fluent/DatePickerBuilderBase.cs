using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using System.Linq.Expressions;
using System.Web.UI;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class DatePickerBuilderBase<TComponent, TBuilder> : ScriptedViewComponentBuilder<TComponent, TBuilder>
        where TComponent : DatePickerBase
        where TBuilder : DatePickerBuilderBase<TComponent, TBuilder>
    {

        private IDatePickerHtmlBuilder htmlBuilder;

        public DatePickerBuilderBase(TComponent component, IDatePickerHtmlBuilder htmlBuilder, IClientSideObjectWriterFactory clientSideObjectWriterFactory, HtmlTextWriter writer) :
            base(component, clientSideObjectWriterFactory, writer)
        {
            Component = component;
            this.htmlBuilder = htmlBuilder;
        }

        public TBuilder Value(DateTime? date)
        {
            Component.Value = date;

            return (TBuilder) this ;
        }

        public TBuilder Value(string date)
        {
            DateTime parsedDate;

            if (DateTime.TryParse(date, out parsedDate))
            {
                Component.Value = parsedDate;
            }
            else
            {
                Component.Value = null;
            }

            return this as TBuilder;
        }

        public override void WriteInitializationScript(HtmlTextWriter writer)
        {
            IClientSideObjectWriter objectWriter = ClientSideObjectWriterFactory.Create(Component.Id, "tDatePicker", writer);

            objectWriter.Start();

            objectWriter.Append("dateFormat", JQueryDatePickerFormatTranslator.Translate(Component.Format));

            objectWriter.AppendClientEvent("onLoad", Component.ClientEvents.OnLoad);
            objectWriter.AppendClientEvent("onChange", Component.ClientEvents.OnChange);
            objectWriter.AppendClientEvent("onOpen", Component.ClientEvents.OnOpen);
            objectWriter.AppendClientEvent("onClose", Component.ClientEvents.OnClose);

            objectWriter.Complete();

            base.WriteInitializationScript(writer);
        }

        public override void WriteHtml(System.Web.UI.HtmlTextWriter writer)
        {
            IHtmlNode rootTag = htmlBuilder.Build();

            rootTag.WriteTo(writer);
            base.WriteHtml(writer);
        }
    }
}
