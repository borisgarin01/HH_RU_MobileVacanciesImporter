using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Roots")]
public class Root
{
    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("found")]
    public int Found { get; set; }

    [JsonProperty("pages")]
    public int Pages { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    [JsonProperty("alternate_url")]
    public string AlternateUrl { get; set; }
}