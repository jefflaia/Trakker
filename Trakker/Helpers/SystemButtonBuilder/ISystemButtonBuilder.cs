using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trakker.Helpers.Icons;
using Trakker.Helpers.Elements;
using System.Web.Mvc;


namespace Trakker.Helpers
{
    public interface ISystemButtonBuilder
    {
        TagBuilder CreateButton(string innerHtml, string action, object attributes);
        void SetIcon(Icon Icon);
        void SetElement(IElement element);
        void SetRelation(Relation relation);
    }
}
