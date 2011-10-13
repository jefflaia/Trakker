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

        private TComponent Component { get; set; }
        private bool _isBackground = false;

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

        public TBuilder Background
        {
            get
            {
                _isBackground = true;
                return this as TBuilder;
            }
        }

        public TBuilder Blue()
        {
            return Color(CssPrimitives.ProgressBar.Blue);
        }

        public TBuilder Red()
        {
            return Color(CssPrimitives.ProgressBar.Red);
        }

        public TBuilder Green()
        {
            return Color(CssPrimitives.ProgressBar.Green);
        }

        public TBuilder Orange()
        {
            return Color(CssPrimitives.ProgressBar.Orange);
        }

        public TBuilder Yellow()
        {
            return Color(CssPrimitives.ProgressBar.Yellow);
        }

        public TBuilder Purple()
        {
            return Color(CssPrimitives.ProgressBar.Purple);
        }

        private TBuilder Color(string colorClass)
        {
            if (_isBackground)
            {
                Component.BackgroundColorClass = colorClass;
                _isBackground = false;
            }
            else
            {
                Component.ColorClass = colorClass;
            }

            return this as TBuilder;
        }
    }
}
