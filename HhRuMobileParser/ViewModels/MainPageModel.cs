using HhRuMobileParser.Models.DTOs;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace HhRuMobileParser.ViewModels;

public class MainPageModel : BaseViewModel
{
    public IAsyncCommand GetVacanciesFromNetworkCommand { get; init; }
    public ObservableCollection<Item> VacanciesObservableCollection { get; private set; }
    private int page = 0;
    public MainPageModel()
    {
        GetVacanciesFromNetworkCommand = new AsyncCommand(GetVacanciesFromNetwork);
    }

    private async Task GetVacanciesFromNetwork()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

        var url = $"https://api.hh.ru/vacancies?text=C%23&search_field=name&employment=full&schedule=remote&page={page}";

        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(content);
            VacanciesObservableCollection = new ObservableCollection<Item>(root.Items);
        }
        else
        {
            // Handle the error
        }
    }
}
