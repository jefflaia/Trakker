using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Data;
using Trakker.Helpers.Table.Controls;

namespace Trakker.Helpers.Table
{
    public class TestTable : HtmlTableBuilder<User>
    {
        public TestTable(IList<User> items) : base(items)
        {
            
        }

        public override void Initialize()
        {
            CreateColumn<DateFormatControl>("Created")
                .SetHeaderText("Date Created:");

            CreateColumn<DateFormatControl>("LastLogin")
                .SetHeaderText("Last logged in on:");

        }
    }
}