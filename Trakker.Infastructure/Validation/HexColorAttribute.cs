using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Validation
{
    public class HexColorAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public HexColorAttribute()
            : base(6)
        {
            MinimumLength = 3;
            ErrorMessageResourceType = typeof(Resources.Validation);
            ErrorMessageResourceName = "StringLength_HexColor";
        }
    }
}
