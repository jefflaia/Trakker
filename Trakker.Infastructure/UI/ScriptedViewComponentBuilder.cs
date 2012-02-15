using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Trakker.Infastructure.UI
{
    public abstract class ScriptedViewComponentBuilder<TViewComponent, TBuilder> : ViewComponentBuilderBase<TViewComponent, TBuilder>, IHideObjectMembers, IHtmlString
        where TViewComponent : ScriptedViewComponent
        where TBuilder : ScriptedViewComponentBuilder<TViewComponent, TBuilder>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBuilderBase&lt;TViewComponent, TBuilder&gt;"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        protected ScriptedViewComponentBuilder(TViewComponent component, IClientSideObjectWriterFactory clientSideObjectWriterFactory, HtmlTextWriter textWriter) :
            base(component, textWriter)
        {
            Component = component;
            ClientSideObjectWriterFactory = clientSideObjectWriterFactory;
        }

        public IClientSideObjectWriterFactory ClientSideObjectWriterFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Sets the name of the component.
        /// </summary>
        /// <param name="componentName">The name.</param>
        /// <returns></returns>
        public virtual TBuilder Name(string name)
        {
            Component.Name = name;

            return this as TBuilder;
        }

        protected virtual void EnsureRequiredSettings()
        {
            if (string.IsNullOrEmpty(Component.Name))
            {
                throw new InvalidOperationException(Resources.TextResource.NameCannotBeBlank);
            }
        }

        public virtual void WriteCleanupScript(HtmlTextWriter writer)
        {
        }

        public virtual void WriteInitializationScript(HtmlTextWriter writer)
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
