using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Trakker.Data
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns all the public properties as a list of Name, Value pairs
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<NameValue<object>> GetProperties(this object item)
        {
            foreach (PropertyInfo property in item.GetType().GetProperties())
            {
                yield return new NameValue<object>(property.Name, () => property.GetValue(item, null));
            }
        }
    }
}
