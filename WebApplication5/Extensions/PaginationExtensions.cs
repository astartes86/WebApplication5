using WebApplication5.Interfaces;
using WebApplication5.Pagination;

namespace WebApplication5.Extensions
{
    /// <summary>
    /// Методы расширения <see creef="IQueryable&lt;TEntity&gt;" /> связанные с постраничным выводом
    /// </summary>
    public static class PaginationExtensions
    {
        /// <summary>
        /// Добавляет постраничную выборку данных
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">источник данных</param>
        /// <param name="pageable">параметры постраничного вывода</param>
        /// <returns>страницу данных <see cref="Page&lt;TEntity&gt;" /></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Page<TEntity> Paginate<TEntity>(this IQueryable<TEntity> query, IPageable pageable)
        {
            if (pageable == null)
            {
                throw new ArgumentNullException(nameof(pageable));
            }

            return query.Paginate(pageable.PageNumber, pageable.PageSize);
        }

        private static Page<TEntity> Paginate<TEntity>(this IQueryable<TEntity> query, int pageNumber, int pageSize)
        {
            ValidatePagingParameters(query, pageNumber, pageSize);

            var total = query.Count();

            var items = query.Skip(pageNumber * pageSize).Take(pageSize);

            return new Page<TEntity>(items, pageNumber, pageSize, total);
        }


        private static void ValidatePagingParameters<TEntity>(IQueryable<TEntity> query, int pageNumber, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Номер страницы должен быть равен или больше 0");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Размер страницы должен быть больше 0");
            }
        }
    }
}
