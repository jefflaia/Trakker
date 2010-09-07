using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Trakker.Helpers
{
    public static class ExpressionHelpers
    {
        public static string GetPropertyName<T>(this Expression<Func<T, object>> expression)
        {
            MemberExpression me;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    break;
                default:
                    me = expression.Body as MemberExpression;
                    break;
            }

            if (me != null)
            {
                return me.Member.Name;
            }

        /*
            switch(expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (expression.Body as MemberExpression).Member.Name;
                case ExpressionType.Call:
                    return (expression.Body as MethodCallExpression).Method.Name;
                case ExpressionType.Convert:
                    var e = expression.Body as UnaryExpression;
                    var o = e.Operand as MemberExpression;
                    return ((expression.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            }
         * */

            throw new InvalidOperationException("Unsupported NodeType: '" + expression.Body.NodeType.ToString() + "'");
        }
    }
}
