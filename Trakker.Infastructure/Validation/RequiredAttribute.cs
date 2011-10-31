using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Validation
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
            : base()
        {
            ErrorMessageResourceType = typeof(Resources.Validation);
            ErrorMessageResourceName = "Required";
        }
    }
}
