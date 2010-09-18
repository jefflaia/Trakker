using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trakker.Helpers.Table.Controls
{
    public class DateFormatControl : TableControl
    {
        public override string FormatCell()
        {
            DateTime dt = (DateTime)Value;

            return dt.Date.ToShortDateString();
        }
    }
}