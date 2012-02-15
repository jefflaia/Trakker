using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace Trakker.Infastructure.UI
{
    public class ScriptedViewComponent : ViewComponentBase
    {
        public ScriptedViewComponent(IAssetManager assetManager) :
            base(assetManager)
        {

        }

        public string Name
        {
            get;
            set;
        }

        public string Id
        {
            get
            {
                // Return from htmlattributes if user has specified
                // otherwise build it from name
                return (HtmlAttributes.ContainsKey("id") ?
                       HtmlAttributes["id"].ToString() :
                       (!string.IsNullOrEmpty(Name) ? Name.Replace(".", HtmlHelper.IdAttributeDotReplacement) : null)).ToLower() + "-input";
            }
        }

    }
}
