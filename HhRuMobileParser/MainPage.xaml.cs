using HhRuMobileParser.Models;
using HhRuMobileParser.Models.DTOs;
using MvvmHelpers.Commands;
using SQLite;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Input;

namespace HhRuMobileParser;

public partial class MainPage : ContentPage
{
    int count = 0;
    HttpClient httpClient = new HttpClient();
    SQLiteAsyncConnection sqliteAsyncConnection = new SQLiteAsyncConnection(DatabasePathHolder.DatabasePath);
    public IEnumerable<Vacancy> Vacancies { get; private set; }

    public ICommand GetVacanciesFromSQLiteCommand { get; set; }
    public ICommand UploadVacanciesToSQLiteFromAPICommand { get; set; }



    public MainPage()
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        BindingContext = this;
        GetVacanciesFromSQLiteCommand = new AsyncCommand(GetVacanciesFromSQLite);
        UploadVacanciesToSQLiteFromAPICommand = new AsyncCommand(UploadVacanciesToSQLiteFromAPI);
        InitializeComponent();
    }

    private async Task UploadVacanciesToSQLiteFromAPI()
    {
        var root = await httpClient.GetFromJsonAsync<Root>("https://api.hh.ru/vacancies?text=C%23&search_field=name&employment=full&schedule=remote");

        var vacanciesWithAllegedURLtoCheckExistanceInSQLiteDatabase = await sqliteAsyncConnection.QueryAsync<Vacancy>("SELECT * FROM Vacancies");

        foreach (var item in root.Items)
        {
            var vacancy = new Vacancy();
            var address = new StringBuilder();
            string companyName = string.Empty;
            string companyURL = string.Empty;
            string requirement = string.Empty;
            string responsibility = string.Empty;
            string vacancyURL = string.Empty;

            if (item.Address != null)
            {
                if (!string.IsNullOrWhiteSpace(item.Address.City))
                    address.Append(item.Address.City);
                if (!string.IsNullOrWhiteSpace(item.Address.Street))
                    address.Append(item.Address.Street);
                if (!string.IsNullOrWhiteSpace(item.Address.Building))
                    address.Append(item.Address.Building);
            }
            if (!string.IsNullOrWhiteSpace(item.Employer.Name))
            {
                companyName = item.Employer.Name;
            }
            if (!string.IsNullOrWhiteSpace(item.Employer.Url))
            {
                companyURL = item.Employer.Url;
            }
            if (item.Snippet is not null)
            {
                if (!string.IsNullOrWhiteSpace(item.Snippet.Responsibility))
                {
                    responsibility = item.Snippet.Responsibility;
                }
                if (!string.IsNullOrWhiteSpace(item.Snippet.Requirement))
                {
                    requirement = item.Snippet.Requirement;
                }
            }
            vacancyURL = item.Url;


            if (vacanciesWithAllegedURLtoCheckExistanceInSQLiteDatabase.FirstOrDefault(a => a.VacancyURL == vacancyURL) is null)
                await sqliteAsyncConnection.InsertAsync(new Vacancy
                {
                    Address = address.ToString(),
                    CompanyName = companyName,
                    CompanyURL = companyURL,
                    Requirement = requirement,
                    Responsibility = responsibility,
                    VacancyURL = vacancyURL
                });
        }
        await GetVacanciesFromSQLite();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async Task GetVacanciesFromSQLite()
    {
        Vacancies = await sqliteAsyncConnection.Table<Vacancy>().ToListAsync();
        vacanciesCollectionView.ItemsSource = Vacancies;
    }
}
