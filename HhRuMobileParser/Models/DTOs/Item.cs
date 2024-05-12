using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.Models.DTOs;

[Table("Items")]
public class Item
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("premium")]
    public bool Premium { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("has_test")]
    public bool HasTest { get; set; }

    [JsonProperty("response_letter_required")]
    public bool ResponseLetterRequired { get; set; }

    [JsonProperty("area")]
    public Area Area { get; set; }

    [JsonProperty("salary")]
    public Salary Salary { get; set; }

    [JsonProperty("type")]
    public Type Type { get; set; }

    [JsonProperty("address")]
    public Address Address { get; set; }

    [JsonProperty("published_at")]
    public DateTime PublishedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("archived")]
    public bool Archived { get; set; }

    [JsonProperty("apply_alternate_url")]
    public string ApplyAlternateUrl { get; set; }

    [JsonProperty("show_logo_in_search")]
    public bool? ShowLogoInSearch { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("alternate_url")]
    public string AlternateUrl { get; set; }

    [JsonProperty("employer")]
    public Employer Employer { get; set; }

    [JsonProperty("snippet")]
    public Snippet Snippet { get; set; }

    [JsonProperty("schedule")]
    public Schedule Schedule { get; set; }

    [JsonProperty("accept_temporary")]
    public bool AcceptTemporary { get; set; }

    [JsonProperty("professional_roles")]
    public List<ProfessionalRole> ProfessionalRoles { get; set; }

    [JsonProperty("accept_incomplete_resumes")]
    public bool AcceptIncompleteResumes { get; set; }

    [JsonProperty("experience")]
    public Experience Experience { get; set; }

    [JsonProperty("employment")]
    public Employment Employment { get; set; }

    [JsonProperty("is_adv_vacancy")]
    public bool IsAdvVacancy { get; set; }

    [JsonProperty("branding")]
    public Branding Branding { get; set; }
}