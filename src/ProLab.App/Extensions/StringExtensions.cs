using System.Text.Json;
using System.Web;

namespace ProLab.App.Extensions;

public static class StringExtensions
{
    public static string ApplyQuery(this string url, object? queryObj)
    {
        if (queryObj == null)
            return url;

        IEnumerable<string> properties = queryObj
            .GetType()
            .GetProperties()
            .Where(p => p.GetValue(queryObj) != null)
            .Select(p =>
            {
                var name = HttpUtility.UrlEncode(p.Name);
                var value = HttpUtility.UrlEncode(JsonSerializer.Serialize(p.GetValue(queryObj), new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                }));
                return $"{name}={value}";
            });

        return url + (url.Contains('?') ? "&" : "?") + string.Join("&", properties);
    }
}
