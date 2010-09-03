using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Trakker.Helpers.Table
{
    public class TableBuilder<T> 
    {
        ICollection<T> _collection;
        IList _properties;
        HtmlTableRowCollection _rows;

        public TableBuilder (ICollection<T> collection)
        {
            _collection = collection;
            _properties = typeof(T).GetProperties().ToList();

            foreach(T item in collection)
            {
                item.GetType().GetProperties();
            }

            HtmlTableCell cell = new HtmlTableCell();

        }
    }
}