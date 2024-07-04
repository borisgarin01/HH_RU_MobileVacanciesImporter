using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Type
{
    [JsonProperty("id"), PrimaryKey]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}