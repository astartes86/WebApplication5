using System.Runtime.Serialization;

namespace WebApplication5.Exceptions
{
    /// <summary>
    /// Ошибка валидации DTO-объекта
    /// </summary>
    [Serializable]
    public class ValidationException : Exception
{
    /// <summary>
    /// Создает экземпляр <see cref="ValidationException" />
    /// </summary>
    public ValidationException()
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="ValidationException" />
    /// </summary>
    public ValidationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="ValidationException" />
    /// </summary>
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Создает экземпляр <see cref="ValidationException" />
    /// </summary>
    protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
}