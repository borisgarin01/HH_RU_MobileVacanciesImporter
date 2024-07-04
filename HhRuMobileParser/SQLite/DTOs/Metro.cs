using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Metro
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    [JsonProperty("station_name")]
    public string StationName { get; set; }

    [JsonProperty("line_name")]
    public string LineName { get; set; }

    [JsonProperty("station_id")]
    public string StationId { get; set; }

    [JsonProperty("line_id")]
    public string LineId { get; set; }

    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lng")]
    public double Lng { get; set; }
}