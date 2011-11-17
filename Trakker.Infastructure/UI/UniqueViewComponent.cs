using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Trakker.Infastructure.UI
{
    public class UniqueViewComponent : ViewComponentBase
    {
        public UniqueViewComponent(ViewContext viewContext, IClientSideObjectWriterFactory clientSideObjectWriterFactory, IAssetManager assetManager) :
            base(viewContext, clientSideObjectWriterFactory, assetManager)
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

        protected override void EnsureRequiredSettings()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException(Resources.TextResource.NameCannotBeBlank);
            }

            base.EnsureRequiredSettings();
        }
    }
}
