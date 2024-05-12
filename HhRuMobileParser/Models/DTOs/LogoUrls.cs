﻿using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("LogoUrls")]
public class LogoUrls
{
    [JsonProperty("90")]
    public string _90 { get; set; }

    [JsonProperty("240")]
    public string _240 { get; set; }

    [JsonProperty("original")]
    public string Original { get; set; }
}