using WebApplication5.Enums;

namespace WebApplication5.Interfaces
{
    /// <summary>
    /// Параметры сортировки
    /// </summary>
    public interface IOrderable
    {
        /// <summary>
        /// Свойство, по которому нужно выполнить сортировку
        /// </summary>
        string Property { get; }

        /// <summary>
        /// Направление сортировки
        /// </summary>
        Direction Direction { get; }
    }
}