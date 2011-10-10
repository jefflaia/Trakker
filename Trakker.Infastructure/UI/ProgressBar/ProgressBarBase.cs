using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarBase : ViewComponentBase, IProgressBar 
    {

        protected IProgressBarHtmlBuilderFactory _renderFactory;

        public ProgressBarBase(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IProgressBarHtmlBuilderFactory renderFactory) :
            base(viewContext, clientSideObjectWriterFactory)
        {
            _renderFactory = renderFactory;

            //set defaults
            Height = 0;
            Width = 250;
            Current = 0;
            Max = 100;
            ColorClass = CssPrimitives.ProgressBar.Blue;
        }

        public IDictionary<string, object> InputHtmlAttributes { get; set; }
        public double Max { get; set; }
        public double Current { get; set; }
        public string ColorClass { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public double Percentage()
        {
            if (Max == 0.0)
            {
                Max = 1;
            }

            return (Current / Max) * 100;
        }

        public double BarWidthPercent()
        {
            return Percentage();
        }

        public int BarWidthPixels()
        {
            if (Max == 0.0)
            {
                Max = 1;
            }

            return Convert.ToInt32(Math.Floor((Current / Max) * Convert.ToDouble(Width)));
        }
        
        protected override void WriteHtml(System.Web.UI.HtmlTextWriter writer)
        {
            IProgressBarBaseHtmlBuilder builder = _renderFactory.Create(this);
            IHtmlNode rootTag = builder.Build();

            rootTag.WriteTo(writer);
            base.WriteHtml(writer);
        }
    



    }
}
