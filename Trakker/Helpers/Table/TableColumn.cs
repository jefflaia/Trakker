using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trakker.Helpers.Table.Controls;
using System.Web.UI;

namespace Trakker.Helpers.Table
{
    public class TableColumn : Trakker.Helpers.Table.ITableColumn
    {
        protected TableControl _control;
        protected TableControl _headerControl;
        protected IList<object> _values;
        protected string _headerText;
        
        public TableColumn(string columnName) 
        {
            Ignore = false;
            Name = columnName;
            _values = new List<object>();
        }

        public TableColumn()
        {
            // TODO: Complete member initialization
        }

        public bool Ignore { get; set; }
        public string Name { get; set; }

        public TableColumn SetControl(TableControl control)
        {
            _control = control;
            return this;
        }

        public TableColumn SetHeaderText(string text)
        {
            _headerText = text;
            return this;
        }

    
        public void RenderTableHeader(HtmlTextWriter writer)
        {
            if (Ignore == false)
            {
                writer.RenderBeginTag("th");
                if (String.IsNullOrEmpty(_headerText))
                {
                    writer.Write(Name);
                }
                else
                {
                    writer.Write(_headerText);
                }
                writer.RenderEndTag();
            }
        }

        public void RenderTableData(object value, HtmlTextWriter writer)
        {
            if (Ignore == false)
            {
                writer.RenderBeginTag("td");

                if (_control != null)
                {
                    _control.Value = value;
                    writer.Write(_control.FormatCell());
                }
                else
                {
                    writer.Write(value.ToString());
                }

                writer.RenderEndTag();
            }
        }

        
    }
}