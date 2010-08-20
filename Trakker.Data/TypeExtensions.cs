using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Collections;

namespace Trakker.Data
{
    public static class TypeExtensions
    {
        public static PropertyInfo GetPrimaryKey(this Type entityType)
        {
            foreach (PropertyInfo property in entityType.GetProperties())
            {
                if (property.IsPrimaryKey())
                {
                    if (property.PropertyType != typeof(int))
                    {
                        throw new ApplicationException(string.Format("Primary key, '{0}', of type '{1}' is not int",
                                                                     property.Name, entityType));
                    }
                    return property;
                }
            }

            throw new ApplicationException(string.Format("No primary key defined for type {0}", entityType.Name));
        }

        public static bool IsLinqEntity(this Type type)
        {
            return type.GetAttributeOf<TableAttribute>() != null;
        }

        public static IEnumerable<PropertyInfo> PropertiesWithAttributeOf(this Type type, Type attributeType)
        {
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.HasAttributeOf(attributeType))
                {
                    yield return property;
                }
            }
        }

        public static TAttribute GetAttributeOf<TAttribute>(this Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(TAttribute), true);
            if (attributes.Length == 0) return default(TAttribute);
            return (TAttribute)attributes[0];
        }

        public static bool IsEnumerable(this Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }


        public static bool IsProxy(this Type type)
        {
            return type.AssemblyQualifiedName.Contains("DynamicProxyGenAssembly2");
        }
    }
}
