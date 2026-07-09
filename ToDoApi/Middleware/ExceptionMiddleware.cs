using ToDoApi.DTOs;
using ToDoApi.Exceptions;

namespace ToDoApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            context.Response.ContentType = "application/json";

            int statusCode;

            if (ex is NotFoundException)
            {
                statusCode = 404;
            }
            else
            {
                statusCode = 500;
            }

            context.Response.StatusCode = statusCode;

            var response = new ErrorResponseDto
            {
                StatusCode = statusCode,
                Message = ex.Message,
                Path = context.Request.Path,
                Timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}