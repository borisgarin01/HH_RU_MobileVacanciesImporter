using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Branding
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}