using System;
using System.Drawing;
using System.Linq.Expressions;

namespace NovelWebsite.Application.Utils
{
    public static class ExpressionCombine<T>
    {
        public static Expression<Func<T, bool>> And(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(Expression.Invoke(expr1, param),
                                        Expression.Invoke(expr2, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Expression<Func<T, bool>> Or(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.Or(Expression.Invoke(expr1, param),
                                        Expression.Invoke(expr2, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
}
