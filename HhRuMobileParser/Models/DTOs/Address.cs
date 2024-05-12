using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Addresses")]
public class Address
{
    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("building")]
    public string Building { get; set; }

    [JsonProperty("lat")]
    public double? Lat { get; set; }

    [JsonProperty("lng")]
    public double? Lng { get; set; }

    [JsonProperty("raw")]
    public string Raw { get; set; }

    [JsonProperty("metro")]
    public Metro Metro { get; set; }

    [JsonProperty("metro_stations")]
    public List<MetroStation> MetroStations { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}