using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Areas")]
public class Area
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}