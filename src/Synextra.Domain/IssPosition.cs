using Newtonsoft.Json;

namespace Synextra.Domain;

public class IssPosition
{
    [JsonProperty("latitude")]
    public double Latitude { get; set; }
    [JsonProperty("longitude")]
    public double Longitude { get; set; }
}