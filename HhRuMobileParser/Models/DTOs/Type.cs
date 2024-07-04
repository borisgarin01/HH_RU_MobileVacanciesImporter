using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

public class Type
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}