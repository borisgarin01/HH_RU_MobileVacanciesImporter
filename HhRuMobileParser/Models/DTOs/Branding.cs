using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Brandings")]
public class Branding
{
    [JsonProperty("type")]
    public string Type { get; set; }
}