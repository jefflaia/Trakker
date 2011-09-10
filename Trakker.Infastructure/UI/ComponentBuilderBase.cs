using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public abstract class ComponentBuilderBase<TComponent, TBuilder> : IComponentBuilder
    {

        public void Build()
        {
            throw new NotImplementedException();
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}
