using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using Trakker.Helpers.Table;
using System.Web.UI;
using System.Linq.Expressions;
namespace Trakker.Helpers
{
    public class HtmlTableBuilder<T> 
    {
        private ICollection<T> _collection;
        private IList _properties;
        private HtmlTextWriter _writer;
        private IDictionary<string, string> _propertiesToIgnore;

        protected const string TAG = "table";
        protected const string THEAD_TAG = "thead";
        protected const string TFOOT_TAG = "tfoot";
        protected const string TBODY_TAG = "tbody";
        protected const string TABLE_HEADER_TAG = "th";
        protected const string TABLE_DATA_TAG = "td";

        public HtmlTableBuilder(ICollection<T> collection)
        {
            _writer = new HtmlTextWriter(HttpContext.Current.Response.Output);
            _collection = collection;
            _properties = typeof(T).GetProperties().ToList();
            _propertiesToIgnore = new Dictionary<string, string>();

            Rows = new Collection<IHtmlTableRow>();
            Header = new HtmlTableRow(_writer);
            ShowTableHeaders = true;
        }

        public void IgnoreProperty(string name)
        {
            _propertiesToIgnore.Add(name, name);
        }

        public void IgnoreProperty(Expression<Func<T, object>> expression)
        {
           string name = expression.GetPropertyName<T>();
            _propertiesToIgnore.Add(name, name);
        }



        
        public ICollection<IHtmlTableRow> Rows { get; set; }

        public bool ShowTableHeaders { get; set; }
        
        public IHtmlTableRow Header { get; set; }
        
        public bool HasPropertyIgnored(string name)
        {            
            return _propertiesToIgnore.ContainsKey(name);
        }

        protected void BuildTableHeader()
        {
            foreach (PropertyInfo property in _properties)
            {
                if(HasPropertyIgnored(property.Name) == false)
                {
                    HtmlTableCell cell = new HtmlTableCell(_writer)
                    {
                        Tag = TABLE_HEADER_TAG
                    };

                    cell.InnerText = property.Name;
                    Header.AddCell(cell);
                }
            }
        }

        protected void BuildTableBody()
        {
            foreach (T item in _collection)
            {
                IHtmlTableRow row = new HtmlTableRow(_writer);

                foreach (PropertyInfo property in _properties)
                {
                    if (HasPropertyIgnored(property.Name) == false)
                    {
                        HtmlTableCell cell = new HtmlTableCell(_writer);
                        cell.InnerText = property.GetValue(item, null).ToString();
                        row.AddCell(cell);
                    }
                }

                Rows.Add(row);
            }           
        }

        public void Render()
        {
            BuildTableHeader();
            BuildTableBody();

            _writer.RenderBeginTag(TAG);

            if (ShowTableHeaders)
            {
                _writer.RenderBeginTag(THEAD_TAG);
                Header.Render();
                _writer.RenderEndTag();
            }

            _writer.RenderBeginTag(TFOOT_TAG);
            _writer.RenderEndTag();


            _writer.RenderBeginTag(TBODY_TAG);
            foreach (IHtmlTableRow row in Rows)
            {
                row.Render();
            }
            _writer.RenderEndTag();

            _writer.RenderEndTag();
        }
    }
}