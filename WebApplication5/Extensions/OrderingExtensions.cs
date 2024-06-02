using System.Linq.Expressions;
using System.Reflection;
using WebApplication5.Enums;
using WebApplication5.Interfaces;

namespace WebApplication5.Extensions
{
    /// <summary>
    /// Методы расширения <see cref="IQueryable&lt;TEntity&gt;" /> связанные с сортировкой
    /// </summary>
    public static class OrderingExtensions
    {
        private static readonly MethodInfo OrderByMethod =
            typeof(Queryable).GetMethods().Single(method =>
            method.Name == "OrderBy" && method.GetParameters().Length == 2);

        private static readonly MethodInfo OrderByDescendingMethod =
            typeof(Queryable).GetMethods().Single(method =>
            method.Name == "OrderByDescending" && method.GetParameters().Length == 2);

        public static IQueryable<TEntity> ApplyOrder<TEntity>(this IQueryable<TEntity> source, IOrderable orderable)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (orderable == null)
            {
                return source;
            }

            if (!IsPropertyExists<TEntity>(orderable.Property))
            {
                throw new InvalidOperationException($"Сущность {typeof(TEntity).Name} не содержит свойства '{orderable.Property}'");
            }

            return orderable.Direction switch
            {
                Direction.Asc => source.OrderByProperty(orderable.Property, OrderByMethod),
                Direction.Desc => source.OrderByProperty(orderable.Property, OrderByDescendingMethod),
                _ => throw new InvalidOperationException("Неподдерживаемый тип сортировки"),
            };
        }

        private static IQueryable<TEntity> OrderByProperty<TEntity>(this IQueryable<TEntity> source, string propertyName, MethodInfo orderingMethod)
        {
            (var orderByProperty, var lambda) = BuildExpressions<TEntity>(propertyName);
            MethodInfo genericMethod = orderingMethod.MakeGenericMethod(typeof(TEntity), orderByProperty.Type);
            object? ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return ret != null
                ? (IQueryable<TEntity>)ret
                : source;
        }

        private static (Expression, LambdaExpression) BuildExpressions<TEntity>(string propertyName)
        {
            ParameterExpression paramterExpression = Expression.Parameter(typeof(TEntity));
            Expression orderByProperty = Expression.Property(paramterExpression, propertyName);
            var lambda = Expression.Lambda(orderByProperty, paramterExpression);
            return (orderByProperty, lambda);
        }

        private static bool IsPropertyExists<TEntity>(string propertyName)
        {
            return typeof(TEntity).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}
