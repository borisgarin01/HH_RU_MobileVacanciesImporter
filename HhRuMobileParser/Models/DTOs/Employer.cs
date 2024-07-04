using Newtonsoft.Json;

namespace HhRuMobileParser.Models.DTOs;

public class Employer
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("alternate_url")]
    public string AlternateUrl { get; set; }

    [JsonProperty("logo_urls")]
    public LogoUrls LogoUrls { get; set; }

    [JsonProperty("vacancies_url")]
    public string VacanciesUrl { get; set; }

    [JsonProperty("accredited_it_employer")]
    public bool AccreditedItEmployer { get; set; }

    [JsonProperty("trusted")]
    public bool Trusted { get; set; }
}