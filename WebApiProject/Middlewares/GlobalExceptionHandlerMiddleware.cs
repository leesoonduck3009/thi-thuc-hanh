using System.Text.Json;
using TestWebApplication.Dtos;

namespace TestWebApplication.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Tiếp tục xử lý yêu cầu
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);
            List<ApiResultError> errors = new List<ApiResultError>();
            errors.Add(new ApiResultError(ApiResultErrorCodes.InternalServerError, ex.Message));
            var response = ApiResult<string>.Failure(errors);
            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(result);
        }
    }
}
