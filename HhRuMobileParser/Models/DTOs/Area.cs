using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

public class Area
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}