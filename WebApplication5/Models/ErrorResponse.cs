namespace WebApplication5.Models
{
    /// <summary>
    /// Объект, возвращаемый API в случае возникновени яошибки
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; init; } = string.Empty;

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; init; } = string.Empty;
    }
}
