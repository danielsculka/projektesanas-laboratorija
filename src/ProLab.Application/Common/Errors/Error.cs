using FluentResults;

namespace ProLab.Application.Common.Errors;

public class Error : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }

    public Error(string code, string message, ErrorType type = ErrorType.Unknown)
    {
        Message = message;
        Metadata = new Dictionary<string, object>
        {
            { "Code", code },
            { "Type", type }
        };
        Reasons = [];
    }
}
