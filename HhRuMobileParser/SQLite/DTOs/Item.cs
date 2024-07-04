using Newtonsoft.Json;
using SQLite;

namespace HhRuMobileParser.SQLite.DTOs;

public class Item
{
    [JsonProperty("id"), PrimaryKey]
    public string Id { get; set; }
    public bool Premium { get; set; }
    public string Name { get; set; }
    public bool HasTest { get; set; }
    public bool ResponseLetterRequired { get; set; }
    public string AreaId { get; set; }
    public long SalaryId { get; set; }
    public string TypeId { get; set; }
    public string AddressId { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Archived { get; set; }
    public string ApplyAlternateUrl { get; set; }
    public bool? ShowLogoInSearch { get; set; }
    public string Url { get; set; }
    public string AlternateUrl { get; set; }
    public string EmployerId { get; set; }
    public long SnippetId { get; set; }
    public string ScheduleId { get; set; }
    public bool AcceptTemporary { get; set; }
    public bool AcceptIncompleteResumes { get; set; }
    public string ExperienceId { get; set; }
    public string EmploymentId { get; set; }
    public bool IsAdvVacancy { get; set; }
    public long BrandingId { get; set; }
}