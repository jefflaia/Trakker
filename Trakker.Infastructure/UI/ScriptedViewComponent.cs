using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace Trakker.Infastructure.UI
{
    public class ScriptedViewComponent : ViewComponentBase
    {
        public ScriptedViewComponent(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IAssetManager assetManager) :
            base(viewContext, assetManager)
        {
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;
        }

        public string Name
        {
            get;
            set;
        }

        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory
        {
            get;
            private set;
        }

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

        protected virtual void EnsureRequiredSettings()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException(Resources.TextResource.NameCannotBeBlank);
            }
        }

        public virtual void WriteCleanupScript(HtmlTextWriter writer)
        {
        }

        public virtual void WriteInitializationScript(System.IO.TextWriter writer)
        {

        }

        public override void WriteHtml(HtmlTextWriter writer)
        {
            EnsureRequiredSettings();

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.RenderEndTag();


        }
    }
}
