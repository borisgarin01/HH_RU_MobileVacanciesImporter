using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class LogoUrls
{
    [JsonProperty("original"), PrimaryKey]
    public string Original { get; set; }

    [JsonProperty("90")]
    public string _90 { get; set; }

    [JsonProperty("240")]
    public string _240 { get; set; }
}