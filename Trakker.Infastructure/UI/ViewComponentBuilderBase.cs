﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Trakker.Infastructure.UI
{
    public abstract class ViewComponentBuilderBase<TViewComponent, TBuilder> : ComponentBuilderBase<TViewComponent, TBuilder>, IHideObjectMembers, IHtmlString
        where TViewComponent : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponent, TBuilder>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBuilderBase&lt;TViewComponent, TBuilder&gt;"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        protected ViewComponentBuilderBase(TViewComponent component)
        {
            Component = component;
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
        /// Sets the name of the component.
        /// </summary>
        /// <param name="componentName">The name.</param>
        /// <returns></returns>
        public virtual TBuilder Name(string componentName)
        {
            Component.Name = componentName;

            return this as TBuilder;
        }

        /// <summary>
        /// Sets the web asset key for the component.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual TBuilder AssetKey(string key)
        {
            Component.AssetKey = key;

            return this as TBuilder;
        }

        /// <summary>
        /// Sets the Scripts files path.. Path must be a virtual path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public virtual TBuilder ScriptFilesPath(string path)
        {
            Component.ScriptFilesPath = path;

            return this as TBuilder;
        }

        /// <summary>
        /// Sets the Script file names.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <returns></returns>
        public virtual TBuilder ScriptFileNames(params string[] names)
        {
            Component.ScriptFileNames.Clear();
            Component.ScriptFileNames.AddRange(names);

            return this as TBuilder;
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

        /// <summary>
        /// Renders the component.
        /// </summary>
        public virtual void Render()
        {
            Component.Render();
        }

        public string ToHtmlString()
        {
            return ToComponent().ToHtmlString();
        }

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