using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

public class Branding
{
    [JsonProperty("type")]
    public string Type { get; set; }
}