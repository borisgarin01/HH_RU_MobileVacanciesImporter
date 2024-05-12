using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Types")]
public class Type
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}