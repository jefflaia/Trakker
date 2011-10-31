using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Trakker.Infastructure.Resources;

namespace Trakker.Infastructure.Validation
{
    public class DateAttribute : DataTypeAttribute
    {
        public DateAttribute() : base(DataType.Date)
        {
            ErrorMessageResourceType = typeof(Resources.Validation);
            ErrorMessageResourceName = "Date";
        }
    }
}
