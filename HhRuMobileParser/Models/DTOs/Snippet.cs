using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Snippets")]
public class Snippet
{
    [JsonProperty("requirement")]
    public string Requirement { get; set; }

    [JsonProperty("responsibility")]
    public string Responsibility { get; set; }
}