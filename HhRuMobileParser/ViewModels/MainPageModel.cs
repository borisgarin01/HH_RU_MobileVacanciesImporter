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
    public GetVacanciesQueryObject[] GetVacanciesQueryObject { get; private set; }

    private List<Item> vacancies = new List<Item>();
    public bool LoadingFromNetworkEnabled { get; private set; } = true;

    public MainPageModel()
    {
        GetVacanciesFromNetworkCommand = new AsyncCommand<GetVacanciesQueryObject[]>(GetVacanciesFromNetwork);
        GetVacanciesQueryObject =
        [
            new GetVacanciesQueryObject
            {
                Employment = "full",
                Page = 0,
                Schedule = "remote",
                SearchFields = ["name", "description"],
                Text = "C#",
                Experience = "noExperience"
            },
            new GetVacanciesQueryObject
            {
                 Employment = "full",
                Page = 0,
                Schedule = "remote",
                SearchFields = ["name", "description"],
                Text = "C#",
                Experience = "between1And3"
            }
        ];
    }

    private async Task GetVacanciesFromNetwork(GetVacanciesQueryObject[] getVacanciesQueryObjects)
    {
        LoadingFromNetworkEnabled = false;
        OnPropertyChanged(nameof(LoadingFromNetworkEnabled));
        
        foreach (var getVacanciesQueryObject in getVacanciesQueryObjects)
        {
            var vacanciesFromQuery = await GetVacanciesFromNetwork(getVacanciesQueryObject);
            vacancies.AddRange(vacanciesFromQuery);
        }
        VacanciesObservableCollection = new ObservableCollection<Item>(vacancies);
        OnPropertyChanged(nameof(VacanciesObservableCollection));

        LoadingFromNetworkEnabled = true;
        OnPropertyChanged(nameof(LoadingFromNetworkEnabled));
    }

    private async Task<IEnumerable<Item>> GetVacanciesFromNetwork(GetVacanciesQueryObject getVacanciesQueryObject)
    {

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

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
                vacancies.AddRange(root.Items);
                getVacanciesQueryObject.Page++;
                await GetVacanciesFromNetwork(getVacanciesQueryObject);
            }
            return vacancies;
        }
        return vacancies;
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
