using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using WebApplication5.Models;

namespace WebApplication5.Exceptions
{
    /// <summary>
    /// Глобальный обработчик ошибок
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Код обработчика
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                (var httpStatus, var result) = GetErrorStatusAndResponse(exception);

                var httpResponse = context.Response;
                httpResponse.ContentType = "application/json";
                httpResponse.StatusCode = (int)httpStatus;

                await httpResponse.WriteAsync(JsonSerializer.Serialize(result));
            }
        }

        private (HttpStatusCode, ErrorResponse) GetErrorStatusAndResponse(Exception exception)
        {
            HttpStatusCode statusCode;
            ErrorResponse response;

            switch (exception)
            {
                case EntityNotFoundException:
                    // not found error
                    response = new ErrorResponse
                    {
                        Code = "not_found",
                        Message = exception.Message
                    };
                    statusCode = HttpStatusCode.NotFound;
                    break;

                case ValidationException:
                    response = new ErrorResponse
                    {
                        Code = "validation_failed",
                        Message = exception.Message
                    };
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    break;

                default:
                    // unhandled error
                    response = new ErrorResponse
                    {
                        Code = "error",
                        Message = exception.Message
                    };
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return (statusCode, response);
        }
    }
}
