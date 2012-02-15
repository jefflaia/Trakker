using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public abstract class ViewComponentBuilderBase<TViewComponent, TBuilder> : ComponentBuilderBase<TViewComponent, TBuilder>, IHideObjectMembers, IHtmlString
        where TViewComponent : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponent, TBuilder>
    {


        protected HtmlTextWriter textWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBuilderBase&lt;TViewComponent, TBuilder&gt;"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        protected ViewComponentBuilderBase(TViewComponent component, HtmlTextWriter writer)
        {
            Component = component;
            this.textWriter = writer;
        }

        protected internal TViewComponent Component
        {
            get;
            set;
        }

        public static implicit operator TViewComponent(ViewComponentBuilderBase<TViewComponent, TBuilder> builder)
        {
            return builder.ToComponent();
        }

        /// <summary>
        /// Returns the internal view component.
        /// </summary>
        /// <returns></returns>
        public TViewComponent ToComponent()
        {
            return Component;
        }

        /// <summary>
        /// Sets the HTML attributes.
        /// </summary>
        /// <param name="attributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TBuilder HtmlAttributes(object attributes)
        {
            Component.HtmlAttributes.Clear();
            Component.HtmlAttributes.Merge(attributes);

            return this as TBuilder;
        }




        public void Render()
        {
            WriteHtml(textWriter);
        }

        public string ToHtmlString()
        {
            return textWriter.ToString();
        }

        public abstract void WriteHtml(HtmlTextWriter writer);


        public override string ToString()
        {
            return ToHtmlString();
        }

        string IHtmlString.ToHtmlString()
        {
            return ToHtmlString();
        }
    }
}
