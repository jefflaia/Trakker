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
using Trakker.Helpers.Table.Controls;

namespace Trakker.Helpers
{
    /*
    Type cellType = typeof(HtmlTableCell<>);

    Type propertyType = property.PropertyType;

    Type constructedType = cellType.MakeGenericType(propertyType);

    var cell = Activator.CreateInstance(constructedType, _writer);
    * */

    public class HtmlTableBuilder<T> 
    {
        private IList<T> _items;
        private IDictionary<string, PropertyInfo> _properties;
        private HtmlTextWriter _writer;
        private IDictionary<string, ITableColumn> _columns;

        public HtmlTableBuilder(IList<T> items)
        {
            _items = items;
            _properties = new Dictionary<string, PropertyInfo>();
            _writer = new HtmlTextWriter(HttpContext.Current.Response.Output);
            _columns = new Dictionary<string, ITableColumn>();
            PropertyInfo[] properties = typeof(T).GetProperties();
           
            for (int i = 0; i < properties.Length; i++)
            {
                _properties.Add(properties[i].Name, properties[i]);
            }

            Initialize();
            
            //create columns if none have been created in Initialize()
            if (_columns.Count <= 0)
            {
                CreateColumns();
            }
        }

        public virtual void Initialize()
        {
        }

        public ITableColumn CreateColumn<TControl>(string name)
        {
            Type type = typeof(TControl);

            TableControl control = (TableControl)Activator.CreateInstance(type);

            ITableColumn column = new TableColumn(name).SetControl(control);

            _columns.Add(name, column);

            return _columns[name];
        }

        public ITableColumn CreateColumn<TControl, TResult>(Expression<Func<T, TResult>> expression)
        {
            return CreateColumn<TControl>(expression.GetPropertyName());
        }
        
        public ITableColumn GetColumn<TResult>(Expression<Func<T, TResult>> expression)
        {
            string name = expression.GetPropertyName();
            if (ColumnExists(name))
            {
                return _columns[name];
            }

            return null;
        }

        public ITableColumn GetColumn(string name)
        {
            if (ColumnExists(name))
            {
                return _columns[name];
            }

            return null;
        }

   
        protected void CreateColumns()
        {
            foreach (KeyValuePair<string, PropertyInfo> propertyPair in _properties)
            {
                _columns.Add(propertyPair.Value.Name, new TableColumn(propertyPair.Value.Name)
                    {
                        Name = propertyPair.Value.Name
                    });
            }
        }


        protected Boolean ColumnExists(string name)
        {
            return _columns.ContainsKey(name);
        }

        public void Render()
        {
            _writer.RenderBeginTag("table");

            _writer.RenderBeginTag("thead");
            foreach (KeyValuePair<String, ITableColumn> column in _columns)
            {
                column.Value.RenderTableHeader(_writer);
            }
            _writer.RenderEndTag(); //thead


            _writer.RenderBeginTag("tbody");
            foreach(T item in _items)
            {
                _writer.RenderBeginTag("tr");
                foreach (KeyValuePair<String, ITableColumn> column in _columns)
                {
                    PropertyInfo property = _properties[column.Value.Name];

                    column.Value.RenderTableData(property.GetValue(item, null), _writer);
                }
                _writer.RenderEndTag();
            }
                 
            _writer.RenderEndTag(); //tbody

            _writer.RenderEndTag(); //table
        }
    }
}