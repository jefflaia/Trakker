using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;
using System.Web.UI;
using System.IO;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarBuilder : ViewComponentBuilderBase<ProgressBar, ProgressBarBuilder>
    {

        private IProgressBarHtmlBuilder htmlBuilder;

        private bool _isBackground = false;

        public ProgressBarBuilder(ProgressBar component, IProgressBarHtmlBuilder htmlBuilder, HtmlTextWriter textWriter) :
            base(component, textWriter)
        {
            Component = component;
            this.htmlBuilder = htmlBuilder;
        }

        public ProgressBarBuilder Width(int width)
        {
            Component.Width = width;
            return this;
        }


        public ProgressBarBuilder Height(int value)
        {
            Component.Height = value;
            return this;
        }

        public ProgressBarBuilder Current(double value)
        {
            Component.Current = value;
            return this;
        }

        public ProgressBarBuilder Current(int value)
        {
            Component.Current = Convert.ToDouble(value);
            return this;
        }

        public ProgressBarBuilder Max(double value)
        {
            Component.Max = value;
            return this;
        }

        public ProgressBarBuilder Max(int value)
        {
            Component.Max = Convert.ToDouble(value);
            return this;
        }

        public ProgressBarBuilder Background
        {
            get
            {
                _isBackground = true;
                return this;
            }
        }

        public ProgressBarBuilder Blue()
        {
            return Color(CssPrimitives.ProgressBar.Blue);
        }

        public ProgressBarBuilder Red()
        {
            return Color(CssPrimitives.ProgressBar.Red);
        }

        public ProgressBarBuilder Green()
        {
            return Color(CssPrimitives.ProgressBar.Green);
        }

        public ProgressBarBuilder Orange()
        {
            return Color(CssPrimitives.ProgressBar.Orange);
        }

        public ProgressBarBuilder Yellow()
        {
            return Color(CssPrimitives.ProgressBar.Yellow);
        }

        public ProgressBarBuilder Purple()
        {
            return Color(CssPrimitives.ProgressBar.Purple);
        }

        private ProgressBarBuilder Color(string colorClass)
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

            return this;
        }

        public override void WriteHtml(HtmlTextWriter writer)
        {
            var rootTag = htmlBuilder.Build();
            rootTag.WriteTo(writer);
        }
    }
}
