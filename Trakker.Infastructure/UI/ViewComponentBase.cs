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
            ViewContext = viewContext;
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;

            HtmlAttributes = new Dictionary<string, object>();
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

        public string Id
        {
            get
            {
                // Return from htmlattributes if user has specified
                // otherwise build it from name
                return (HtmlAttributes.ContainsKey("id") ?
                       HtmlAttributes["id"].ToString() :
                       (!string.IsNullOrEmpty(Name) ? Name.Replace(".", HtmlHelper.IdAttributeDotReplacement) : null)).ToLower() + "-input";
            }
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory
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

        protected virtual void EnsureRequiredSettings()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException(Resources.TextResource.NameCannotBeBlank);
            }
        }

        protected virtual void WriteHtml(HtmlTextWriter writer)
        {
            EnsureRequiredSettings();

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            WriteInitializationScript(writer);
            writer.RenderEndTag();
        }

    }
}
