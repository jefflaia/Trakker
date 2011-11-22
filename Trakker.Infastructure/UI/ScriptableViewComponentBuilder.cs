using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Trakker.Infastructure.UI
{
    public abstract class ScriptableViewComponentBuilder<TViewComponent, TBuilder> : ViewComponentBuilderBase<TViewComponent, TBuilder>, IHideObjectMembers, IHtmlString
        where TViewComponent : ScriptableViewComponent
        where TBuilder : ScriptableViewComponentBuilder<TViewComponent, TBuilder>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBuilderBase&lt;TViewComponent, TBuilder&gt;"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        protected ScriptableViewComponentBuilder(TViewComponent component) : 
            base(component)
        {
            Component = component;
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

        
    }
}
