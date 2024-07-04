using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Salary
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }

    [JsonProperty("from")]
    public int? From { get; set; }

    [JsonProperty("to")]
    public int? To { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("gross")]
    public bool Gross { get; set; }
}