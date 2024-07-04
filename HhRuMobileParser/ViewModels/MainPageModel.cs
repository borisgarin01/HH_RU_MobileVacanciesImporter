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
    public IAsyncCommand<GetVacanciesQueryObject> GetVacanciesFromNetworkCommand { get; init; }
    public ObservableCollection<Item> VacanciesObservableCollection { get; private set; }
    public GetVacanciesQueryObject GetVacanciesQueryObject { get; private set; }
    private List<Item> VacanciesToAgregate = new();
    public MainPageModel()
    {
        GetVacanciesFromNetworkCommand = new AsyncCommand<GetVacanciesQueryObject>(GetVacanciesFromNetwork);
        GetVacanciesQueryObject = new GetVacanciesQueryObject
        {
            Employment = "full",
            Page = 0,
            Schedule = "remote",
            SearchFields = ["name", "description"],
            Text = "C#",
            Experience = "noExperience"
        };
    }

    private async Task GetVacanciesFromNetwork(GetVacanciesQueryObject getVacanciesQueryObject)
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
                VacanciesToAgregate.AddRange(root.Items);
                getVacanciesQueryObject.Page++;
                await GetVacanciesFromNetwork(getVacanciesQueryObject);
            }
            else
            {
                DisplayParsedData();
            }
        }
        else
        {
            DisplayParsedData();
        }
    }

    private void DisplayParsedData()
    {
        VacanciesObservableCollection = new ObservableCollection<Item>(VacanciesToAgregate);
        OnPropertyChanged(nameof(VacanciesObservableCollection));
    }
}
