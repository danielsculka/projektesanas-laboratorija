using ProLab.Application.Common.Errors;

namespace ProLab.Infrastructure.OpenRoute;

public static class OpenRouteErrors
{

    public static readonly Error Fetch = new("OpenRoute.Fetch", $"Failed to fetch data.", ErrorType.BadRequest);
}
