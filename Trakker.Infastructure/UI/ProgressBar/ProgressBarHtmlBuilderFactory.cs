using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarHtmlBuilderFactory : IProgressBarHtmlBuilderFactory
    {
        public IProgressBarBaseHtmlBuilder Create(ProgressBarBase element)
        {
            return new ProgressBarBaseHtmlBuilder(element);
        }
    }
}
