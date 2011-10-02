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
    public abstract class ViewComponentBase : IScriptableComponent, IAttributesContainer
    {
        protected ViewComponentBase(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory)
        {

        }
        
        public string AssetKey
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ScriptFilesPath
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<string> ScriptFileNames
        {
            get { throw new NotImplementedException(); }
        }

        public string Name { get; set; }

        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory
        {
            get;
            private set;
        }

        public void WriteInitializationScript(System.IO.TextWriter writer)
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

        public bool IsSelfInitialized
        {
            get;
            private set;
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

        public IDictionary<string, object> HtmlAttributes
        {
            get;
            set;
        }
    }
}
