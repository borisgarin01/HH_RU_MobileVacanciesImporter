using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

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