using System;
using System.Data.Entity.Core.Objects;
using System.Linq.Expressions;
using System.Reflection;

namespace Iot.Common
{
    /// <summary>
    /// Class ObjectQueryExtensionMethods.
    /// </summary>
    /// <remarks>
    ///     found on StackOverflow
    ///     http://www.nearinfinity.com/blogs/joe_ferner/type-safe_entity_framework_inc.html     
    /// </remarks>
    /// <example>
    ///     ctx.Users.Include(u => u.Order.Item);
    /// </example>
    public static class ObjectQueryExtensionMethods
    {
        /// <summary>
        /// Includes the specified query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>ObjectQuery&lt;T&gt;.</returns>
        public static ObjectQuery<T> Include<T>(this ObjectQuery<T> query, Expression<Func<T, object>> exp)
        {
            Expression body = exp.Body;
            MemberExpression memberExpression = (MemberExpression)exp.Body;
            string path = GetIncludePath(memberExpression);
            return query.Include(path);
        }

        /// <summary>
        /// Gets the include path.
        /// </summary>
        /// <param name="memberExpression">The member expression.</param>
        /// <returns>System.String.</returns>
        private static string GetIncludePath(MemberExpression memberExpression)
        {
            string path = "";
            var expression = memberExpression.Expression as MemberExpression;
            if (expression != null)
            {
                path = GetIncludePath(expression) + ".";
            }
            PropertyInfo propertyInfo = (PropertyInfo)memberExpression.Member;
            return path + propertyInfo.Name;
        }
    }

}
