using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

public class Snippet
{
    [JsonProperty("requirement")]
    public string Requirement { get; set; }

    [JsonProperty("responsibility")]
    public string Responsibility { get; set; }
}