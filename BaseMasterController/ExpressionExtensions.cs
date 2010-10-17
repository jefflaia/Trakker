namespace Trakker.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Routing;
    using System.Web.Mvc;

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

        public static RouteValueDictionary GetRouteValuesFromExpression<TController>(this Expression<Action<TController>> action) where TController : Controller
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            MethodCallExpression call = action.Body as MethodCallExpression;
            if (call == null)
            {
                throw new Exception("call is null");
            }

            string controllerName = typeof(TController).Name;
            if (!controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("TController name does not end with controller");
            }
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);
            if (controllerName.Length == 0)
            {
                throw new Exception("cannot be base controller");
            }

            // TODO: How do we know that this method is even web callable?
            //      For now, we just let the call itself throw an exception.

            string actionName = GetTargetActionName(call.Method);

            var rvd = new RouteValueDictionary();
            rvd.Add("controller", controllerName);
            rvd.Add("action", actionName);

            return rvd;
        }

        private static string GetTargetActionName(MethodInfo methodInfo)
        {
            string methodName = methodInfo.Name;

            // do we know this not to be an action?
            if (methodInfo.IsDefined(typeof(NonActionAttribute), true /* inherit */))
            {
                throw new Exception();
            }

            // has this been renamed?
            ActionNameAttribute nameAttr = methodInfo.GetCustomAttributes(typeof(ActionNameAttribute), true /* inherit */).OfType<ActionNameAttribute>().FirstOrDefault();
            if (nameAttr != null)
            {
                return nameAttr.Name;
            }

            // targeting an async action?
            if (methodInfo.DeclaringType.IsSubclassOf(typeof(AsyncController)))
            {
                if (methodName.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
                {
                    return methodName.Substring(0, methodName.Length - "Async".Length);
                }
                if (methodName.EndsWith("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception();
                }
            }

            // fallback
            return methodName;
        }
    }
}
