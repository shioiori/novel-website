using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System;
using System.Drawing;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Utils
{
    public static class ExpressionUtil<T>
    {
        public static Expression<Func<T, bool>> Combine(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(Expression.Invoke(expr1, param),
                                        Expression.Invoke(expr2, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
}
