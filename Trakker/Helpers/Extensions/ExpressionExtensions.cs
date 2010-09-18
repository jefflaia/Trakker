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
            switch (expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpression = (MemberExpression)expression.Body;
                    return memberExpression.Member is PropertyInfo ? memberExpression.Member.Name : null;
                    
                case ExpressionType.Convert:
                    MemberExpression memberExpr = expression.Body as MemberExpression;
                    if (memberExpr == null) 
                    {
                        UnaryExpression unaryExpr = expression.Body as UnaryExpression;
                        if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                        {
                            memberExpr = unaryExpr.Operand as MemberExpression;
                        }

                        if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                        {
                            return memberExpr.Member.Name;
                        }
                    }
                    break;

            }            

            throw new InvalidOperationException("Unsupported NodeType: '" + expression.Body.NodeType.ToString() + "'");
        }

        public static PropertyInfo GetProperty<TParameter, TValue>(this Expression<Func<TParameter, TValue>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)expression.Body;
                
                if(memberExpression.Member is PropertyInfo)
                {
                    return memberExpression.Member as PropertyInfo;
                }
            }

            throw new InvalidOperationException("Unsupported NodeType: '" + expression.Body.NodeType.ToString() + "'");
        }
    }
}
