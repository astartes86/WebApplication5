using System.Runtime.Serialization;

namespace WebApplication5.Exceptions
{
    /// <summary>
    /// Исключение - сущность не найдена
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Создает экземпляр <see cref="EntityNotFoundException" />
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Создает экземпляр <see cref="EntityNotFoundException" />
        /// </summary>
        /// <param name="message">сообщение об ошибке</param>
        public EntityNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Создает экземпляр <see cref="EntityNotFoundException" />
        /// </summary>
        /// <param name="message">сообщение об ошибке</param>
        /// <param name="innerException">вложенное исключение</param>
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Создает экземпляр <see cref="EntityNotFoundException" />
        /// </summary>
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
