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
        public static string GetPropertyName<TParameter, TValue>(this Expression<Func<TParameter, TValue>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                    MemberExpression memberExpression = (MemberExpression)expression.Body;
                    return memberExpression.Member is PropertyInfo ? memberExpression.Member.Name : null;
                    
            }

            throw new InvalidOperationException("Unsupported NodeType: '" + expression.Body.NodeType.ToString() + "'");
        }
    }
}
