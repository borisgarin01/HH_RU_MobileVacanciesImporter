using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Address
{
    [JsonProperty("id")]
    [PrimaryKey]
    public string Id { get; set; }
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

    public long MetroId { get; set; }
   
}