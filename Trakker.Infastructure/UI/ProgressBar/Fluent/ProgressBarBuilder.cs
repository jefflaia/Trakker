using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Infastructure.Uploading;

namespace Trakker.Infastructure.UI
{
    public class ProgressBarBuilder : ProgressBarBuilderBase<ProgressBarBase, ProgressBarBuilder>
    {
        public ProgressBarBuilder(ProgressBarBase component)
            : base(component)
        {
        }
    }
}
