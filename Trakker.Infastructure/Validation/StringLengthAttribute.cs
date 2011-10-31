using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.Validation
{
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthAttribute(int length)
            : base(length)
        {
            ErrorMessageResourceType = typeof(Resources.Validation);
            ErrorMessageResourceName = String.Concat("StringLength_", length.ToString());
        }
    }
}
