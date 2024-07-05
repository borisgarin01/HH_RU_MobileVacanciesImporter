using HhRuMobileParser.Models.DTOs;
using HhRuMobileParser.QueriesObjects;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Web;

namespace HhRuMobileParser.ViewModels;

public class MainPageModel : BaseViewModel
{
    public IAsyncCommand<GetVacanciesQueryObject[]> GetVacanciesFromNetworkCommand { get; init; }
    public ObservableCollection<Item> VacanciesObservableCollection { get; private set; }
    public GetVacanciesQueryObject[] GetVacanciesQueryObjects { get; private set; }
    private List<Item> VacanciesToAgregate = new();

    HttpClient httpClient = new();

    public MainPageModel()
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

        GetVacanciesFromNetworkCommand = new AsyncCommand<GetVacanciesQueryObject[]>(GetVacanciesFromNetwork);
        GetVacanciesQueryObjects =
        [
            new GetVacanciesQueryObject
            {
                Employment = "full",
                Page = 0,
                Schedule = "remote",
                SearchFields = ["name", "description"],
                Text = "C#",
                Experience = "noExperience"
            }
        ];
    }

    private async Task GetVacanciesFromNetwork(GetVacanciesQueryObject[] getVacanciesQueryObjects)
    {
        foreach (var getVacanciesQueryObject in getVacanciesQueryObjects)
        {
            await GetVacanciesFromNetwork(getVacanciesQueryObject);
        }

        await DisplayImportDataWithImportingToSQLite(VacanciesToAgregate);
    }

    private async Task GetVacanciesFromNetwork(GetVacanciesQueryObject getVacanciesQueryObject)
    {
        var searchFields =
        string.Join('&', getVacanciesQueryObject.SearchFields.Select(a => $"search_field={a}"));

        var url = $"https://api.hh.ru/vacancies?text={HttpUtility.UrlEncode(getVacanciesQueryObject.Text)}&employment={getVacanciesQueryObject.Employment}&schedule={getVacanciesQueryObject.Schedule}&experience={getVacanciesQueryObject.Experience}&page={getVacanciesQueryObject.Page}&{searchFields}";

        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(content);
            if (root.Items.Count > 0)
            {
                VacanciesToAgregate.AddRange(root.Items);
                getVacanciesQueryObject.Page++;
                await GetVacanciesFromNetwork(getVacanciesQueryObject);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    private async Task DisplayImportDataWithImportingToSQLite(IEnumerable<Item> items)
    {
        DisplayParsedData(items);
    }

    private void DisplayParsedData(IEnumerable<Item> items)
    {
        VacanciesObservableCollection = new ObservableCollection<Item>(items);
        OnPropertyChanged(nameof(VacanciesObservableCollection));
    }
}
