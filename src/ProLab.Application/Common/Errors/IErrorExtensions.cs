using FluentResults;

namespace ProLab.Application.Common.Errors;

public static class IErrorExtensions
{
    public static string? GetErrorCode(this IError error)
    {
        return error.Metadata.TryGetValue("Code", out var code)
            ? code.ToString()
            : null;
    }

    public static ErrorType GetErrorType(this IError error)
    {
        return error.Metadata.TryGetValue("Type", out var type)
            ? (ErrorType)type
            : ErrorType.Unknown;
    }
}
