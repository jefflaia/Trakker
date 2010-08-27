using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;

namespace Trakker.Data
{
    public static class PropertyInfoExtensions
    {
        public static bool HasAttributeOf(this PropertyInfo property, Type attributeType)
        {
            object[] attributes = property.GetCustomAttributes(attributeType, true);
            return attributes.Length > 0;
        }

        public static bool HasAttributeOf<TAttribute>(this PropertyInfo propertyInfo)
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true);
            return attributes.Length > 0;
        }

        public static TAttribute GetAttributeOf<TAttribute>(this PropertyInfo propertyInfo)
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true);
            if (attributes.Length == 0)
            {
                return default(TAttribute);
            }
            return (TAttribute)attributes[0];
        }

        public static bool IsPrimaryKey(this PropertyInfo propertyInfo)
        {
            var columnAttribute = propertyInfo.GetAttributeOf<ColumnAttribute>();
            if (columnAttribute == null) return false;
            return columnAttribute.IsPrimaryKey;
        }

        public static bool IsForeignKey(this PropertyInfo propertyInfo)
        {
            var association = propertyInfo.GetAttributeOf<AssociationAttribute>();
            if (association == null) return false;
            return association.IsForeignKey;
        }

        public static string ForeignKeyIdField(this PropertyInfo propertyInfo)
        {
            var association = propertyInfo.GetAttributeOf<AssociationAttribute>();
            if (association == null) return null;
            return association.ThisKey;
        }

    }
}
