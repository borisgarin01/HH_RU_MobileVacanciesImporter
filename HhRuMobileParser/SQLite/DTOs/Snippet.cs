using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Snippet
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    [JsonProperty("requirement")]
    public string Requirement { get; set; }

    [JsonProperty("responsibility")]
    public string Responsibility { get; set; }
}