using FluentResults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProLab.Infrastructure.OpenRoute.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProLab.Infrastructure.OpenRoute;

public class OpenRouteClient : IOpenRouteClient
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _serializerOption;
    private readonly OpenRouteOptions _options;
    private readonly ILogger<OpenRouteClient> _logger;

    public OpenRouteClient(HttpClient httpClient, IOptions<OpenRouteOptions> options, ILogger<OpenRouteClient> logger)
    {
        _http = httpClient;
        _options = options.Value;
        _logger = logger;

        _serializerOption = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    public async Task<Result<OpenRouteDirectionsResponse>> GetDirectionsAsync(OpenRouteDirectionsRequest requestContent, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Getting directions.");

        string url = $"{_options.Url}/directions/driving-car";

        HttpRequestMessage request = CreateRequest(HttpMethod.Post, url, requestContent);
        HttpResponseMessage response = await _http.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return Result.Fail(OpenRouteErrors.Fetch);

        OpenRouteDirectionsResponse? result = await HandleResponseAsync<OpenRouteDirectionsResponse>(response, cancellationToken);

        if (result == null)
            return Result.Fail(OpenRouteErrors.Fetch);

        _logger.LogInformation("Received directions.");

        return result;
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string url, object? content = null)
    {
        var request = new HttpRequestMessage(method, url);

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.UserToken);

        if (content != null)
        {
            var json = JsonSerializer.Serialize(content, _serializerOption);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = requestContent;

            _logger.LogDebug("Request content: {content}", requestContent);
        }

        return request;
    }

    private async Task<TResult?> HandleResponseAsync<TResult>(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        _logger.LogDebug("Response content: {content}", responseContent);

        return JsonSerializer.Deserialize<TResult>(responseContent, _serializerOption);
    }
}
