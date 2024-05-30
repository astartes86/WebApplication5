namespace WebApplication5.Pagination
{
    /// <summary>
    /// Страница данных
    /// </summary>
    /// <typeparam name="TEntity">тип элемента</typeparam>
    public class Page<TEntity>
    {
        /// <summary>
        /// Создает экземпляр страницы данных
        /// </summary>
        /// <param name="items">коллекция элементов</param>
        /// <param name="pageNumber">номер страницы. нумерация начинается с 0</param>
        /// <param name="size">размер страницы</param>
        /// <param name="totalElements">общее число элементов</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Page(IEnumerable<TEntity> items, int pageNumber, int size, long totalElements)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Размер страницы должен быть больше 0");
            }

            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Номер страницы должен быть равен или больше 0");
            }

            Content = new List<TEntity>(items);
            PageMetadata = new PageMetadata
            {
                Number = pageNumber,
                Size = size,
                Count = Content.Count,
                TotalElements = totalElements
            };
        }

        /// <summary>
        /// Метаданные
        /// </summary>
        public PageMetadata PageMetadata { get; }

        /// <summary>
        /// Набор данных
        /// </summary>
        public ICollection<TEntity> Content { get; }
    }
}
