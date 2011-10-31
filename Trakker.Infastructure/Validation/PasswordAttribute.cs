using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Trakker.Infastructure.Resources;

namespace Trakker.Infastructure.Validation
{
    public class PasswordAttribute : DataTypeAttribute
    {
        public PasswordAttribute()
            : base(DataType.Password)
        {
            ErrorMessageResourceType = typeof(Resources.Validation);

        }
    }
}
