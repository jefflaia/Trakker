using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Helpers.Icons
{
    public abstract class BaseIcon : IIcon
    {

        protected string _positionCssClass;

        public BaseIcon()
        {
            _positionCssClass = string.Empty;
        }

        public TagBuilder Get()
        {
            TagBuilder div = new TagBuilder("div ");
            div.AddCssClass("Icon");
            div.AddCssClass(_positionCssClass);

            return div;
        }

        public void SetPositionClass(string cssClass)
        {
            _positionCssClass = cssClass;
        }
    }
}