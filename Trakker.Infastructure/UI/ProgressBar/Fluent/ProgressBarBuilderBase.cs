using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarBuilderBase<TComponent, TBuilder> : ViewComponentBuilderBase<TComponent, TBuilder>
        where TComponent : ProgressBarBase
        where TBuilder : ProgressBarBuilderBase<TComponent, TBuilder>
    {

        public TComponent Component { get; set; }

        public ProgressBarBuilderBase(TComponent component) :
            base(component)
        {
            Component = component;
        }

        public TBuilder Width(int width)
        {
            Component.Width = width;
            return this as TBuilder;
        }


        public TBuilder Height(int value)
        {
            Component.Height = value;
            return this as TBuilder;
        }

        public TBuilder Current(double value)
        {
            Component.Current = value;
            return this as TBuilder;
        }

        public TBuilder Current(int value)
        {
            Component.Current = Convert.ToDouble(value);
            return this as TBuilder;
        }

        public TBuilder Max(double value)
        {
            Component.Max = value;
            return this as TBuilder;
        }

        public TBuilder Max(int value)
        {
            Component.Max = Convert.ToDouble(value);
            return this as TBuilder;
        }

        public TBuilder Blue()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Blue;
            return this as TBuilder;
        }

        public TBuilder Red()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Red;
            return this as TBuilder;
        }

        public TBuilder Green()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Green;
            return this as TBuilder;
        }

        public TBuilder Orange()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Orange;
            return this as TBuilder;
        }

        public TBuilder Yellow()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Yellow;
            return this as TBuilder;
        }

        public TBuilder Purple()
        {
            Component.ColorClass = CssPrimitives.ProgressBar.Purple;
            return this as TBuilder;
        }
    }
}
