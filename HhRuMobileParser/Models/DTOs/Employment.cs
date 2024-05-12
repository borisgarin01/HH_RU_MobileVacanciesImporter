using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Employments")]
public class Employment
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}