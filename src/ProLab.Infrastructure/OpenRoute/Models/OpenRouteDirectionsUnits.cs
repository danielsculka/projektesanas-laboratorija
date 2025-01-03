using System.Text.Json.Serialization;

namespace ProLab.Infrastructure.OpenRoute.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OpenRouteDirectionsUnits
{
    [JsonPropertyName("km")]
    Kilometers,

    [JsonPropertyName("mi")]
    Miles
}
