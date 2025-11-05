using System.Text.Json;

namespace FlockWise.API.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred. RequestPath: {RequestPath}", 
                context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var (statusCode, message) = GetErrorResponse(exception);
        context.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
            Message = message,
            StatusCode = statusCode,
            Timestamp = DateTime.UtcNow
        };
        
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment == "Development")
        {
            response.Details = exception.ToString();
        }

        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }

    private static (int statusCode, string message) GetErrorResponse(Exception exception)
    {
        return exception switch
        {
            ArgumentException => (400, "Invalid request parameters"),
            UnauthorizedAccessException => (401, "Unauthorized access"),
            NotImplementedException => (501, "Feature not implemented"),
            TimeoutException => (408, "Request timeout"),
            _ => (500, "An internal server error occurred")
        };
    }
}