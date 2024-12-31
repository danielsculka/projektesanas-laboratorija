using FastEndpoints;
using System.Net.Mime;

namespace ProLab.Api.Core;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Unhandled exception occurred");

        var statusCode = StatusCodes.Status500InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Instance = context.Request.Path,
            Errors = new List<ProblemDetails.Error>
            {
                new() {
                    Code = "Global.InternalServerError",
                    Reason = "An unexpected error occurred."
                }
            }
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = MediaTypeNames.Application.ProblemJson;

        return context.Response.WriteAsJsonAsync(problemDetails);
    }
}
