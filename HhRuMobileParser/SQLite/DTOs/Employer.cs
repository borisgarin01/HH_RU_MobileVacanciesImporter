using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Employer
{
    [JsonProperty("id"), PrimaryKey]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("alternate_url")]
    public string AlternateUrl { get; set; }

    public long LogoURLsId { get; set; }

    [JsonProperty("vacancies_url")]
    public string VacanciesUrl { get; set; }

    [JsonProperty("accredited_it_employer")]
    public bool AccreditedItEmployer { get; set; }

    [JsonProperty("trusted")]
    public bool Trusted { get; set; }
}