using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Web;

namespace Trakker.Infastructure.UI
{
    public abstract class ViewComponentBase : IAttributesContainer
    {
        protected ViewComponentBase(ViewContext viewContext, IAssetManager assetManager)
        {
            ViewContext = viewContext;
            AssetManager = assetManager;

            HtmlAttributes = new Dictionary<string, object>();
        }

        public IAssetManager AssetManager 
        { 
            get; 
            private set; 
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

        public virtual void WriteInitializationScript(System.IO.TextWriter writer)
        {
            
        }

        public ViewContext ViewContext
        {
            get;
            private set;
        }

        public void Render()
        {
            using (HtmlTextWriter textWriter = new HtmlTextWriter(ViewContext.HttpContext.Response.Output))
            {
                WriteHtml(textWriter);
            }
        }

        public virtual void WriteCleanupScript(TextWriter writer)
        {
        }

        public string ToHtmlString()
        {
            using (var output = new StringWriter())
            {
                WriteHtml(new HtmlTextWriter(output));
                return output.ToString();
            }
        }

        protected virtual void WriteHtml(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            WriteInitializationScript(writer);
            writer.RenderEndTag();
        }

    }
}
