using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Salaries")]
public class Salary
{
    [JsonProperty("from")]
    public int? From { get; set; }

    [JsonProperty("to")]
    public int? To { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("gross")]
    public bool Gross { get; set; }
}