using FastEndpoints;
using FluentResults;
using ProLab.Application.Common.Errors;
using System.Net.Mime;

namespace ProLab.Api.Extensions;

public static class IEndpointExtensions
{
    public static Task SendResultAsync(this IEndpoint endpoint, IResultBase result, CancellationToken cancellationToken)
    {
        return result.IsSuccess
            ? endpoint.HttpContext.Response.SendNoContentAsync(cancellationToken)
            : SendFailedResultAsync(endpoint, result, cancellationToken);
    }

    public static Task SendResultAsync<TRequest, TResponse>(
        this Endpoint<TRequest, TResponse> endpoint,
        IResult<TResponse> result,
        CancellationToken cancellationToken
        )
        where TRequest : notnull
    {
        return result.IsSuccess
            ? endpoint.HttpContext.Response.SendAsync(result.ValueOrDefault, cancellation: cancellationToken)
            : SendFailedResultAsync(endpoint, result, cancellationToken);
    }

    public static Task SendResultAsync<TRequest, TResponse, TValue>(
        this Endpoint<TRequest, TResponse> endpoint,
        IResult<TValue> result,
        Func<TValue, TResponse> mapper,
        CancellationToken cancellationToken
        )
        where TRequest : notnull
    {
        return result.IsSuccess
            ? endpoint.HttpContext.Response.SendAsync(mapper(result.ValueOrDefault), cancellation: cancellationToken)
            : SendFailedResultAsync(endpoint, result, cancellationToken);
    }

    private static Task SendFailedResultAsync(this IEndpoint endpoint, IResultBase resultBase, CancellationToken cancellationToken)
    {
        endpoint.HttpContext.MarkResponseStart();

        var statusCode = GetFailedStatusCode(resultBase);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Instance = endpoint.HttpContext.Request.Path,
            Errors = resultBase.Errors.Select(e => new ProblemDetails.Error
            {
                Code = e.GetErrorCode(),
                Reason = e.Message
            }).ToArray()
        };

        endpoint.HttpContext.Response.StatusCode = statusCode;
        endpoint.HttpContext.Response.ContentType = MediaTypeNames.Application.ProblemJson;

        return endpoint.HttpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }

    private static int GetFailedStatusCode(IResultBase resultBase)
    {
        ErrorType? errorType = resultBase.Errors.FirstOrDefault()?.GetErrorType();

        return errorType switch
        {
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.ValidationError => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
