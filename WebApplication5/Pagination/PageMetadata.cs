namespace WebApplication5.Pagination
{
    /// <summary>
    /// Метаданные страницы данных
    /// </summary>
    public class PageMetadata
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Number { get; init; }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int Size { get; init; }

        public int Count { get; init; }

        /// <summary>
        /// Общее количество сущностей в БД
        /// </summary>
        public long TotalElements { get; init; }

        /// <summary>
        /// Общее число страниц данных
        /// </summary>
        public int TotalPages => (int)(TotalElements / Size);

        public int From => Number * Size;

        public int To => Number * Size + Count;
    }
}
