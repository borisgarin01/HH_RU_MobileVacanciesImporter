namespace HhRuMobileParser.QueriesObjects;

public sealed record GetVacanciesQueryObject
{
    public string Text { get; init; }
    public string[] SearchFields { get; init; }
    public string Employment { get; init; }
    public string Schedule { get; init; }
    public int Page { get; set; }
    public string Experience { get; init; }
}
