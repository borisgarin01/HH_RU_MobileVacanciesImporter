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
    int page = 0;
    HttpClient httpClient = new HttpClient();
    SQLiteAsyncConnection sqliteAsyncConnection = new SQLiteAsyncConnection(DatabasePathHolder.DatabasePath);
    public IEnumerable<Vacancy> Vacancies { get; private set; }

    public ICommand GetVacanciesFromSQLiteCommand { get; set; }
    public ICommand UploadVacanciesToSQLiteFromAPICommand { get; set; }

    StringBuilder address = new StringBuilder();

    private string companyName;
    private string companyURL;
    private string requirement;
    private string responsibility;
    private string vacancyURL;
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
        GC.Collect();
        try
        {
            Root root = await httpClient.GetFromJsonAsync<Root>($"https://api.hh.ru/vacancies?text=C%23&search_field=name&employment=full&schedule=remote&page={page}");

            page++;

            var vacanciesWithAllegedURLtoCheckExistanceInSQLiteDatabase = (await sqliteAsyncConnection.QueryAsync<Vacancy>("SELECT * FROM Vacancies")).ToArray();

            foreach (var item in root.Items)
            {
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
                address.Clear();
            }
            await UploadVacanciesToSQLiteFromAPI();
            GC.Collect();
        }
        catch
        {
            page = 0;
            await GetVacanciesFromSQLite();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async Task GetVacanciesFromSQLite()
    {
        GC.Collect();
        Vacancies = await sqliteAsyncConnection.Table<Vacancy>().ToArrayAsync();
        vacanciesCollectionView.ItemsSource = Vacancies;
        GC.Collect();
    }
}
