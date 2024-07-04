using HhRuMobileParser.SQLite.DTOs;
using SQLite;

namespace HhRuMobileParser;

public partial class App : Application
{
    private readonly SQLiteAsyncConnection sqliteAsyncConnection = new(Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HhRuMobileParser.db"));
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
    protected override async void OnStart()
    {
        await sqliteAsyncConnection.CreateTableAsync<Address>();
        await sqliteAsyncConnection.CreateTableAsync<Area>();
        await sqliteAsyncConnection.CreateTableAsync<Branding>();
        await sqliteAsyncConnection.CreateTableAsync<Employer>();
        await sqliteAsyncConnection.CreateTableAsync<Employment>();
        await sqliteAsyncConnection.CreateTableAsync<Experience>();
        await sqliteAsyncConnection.CreateTableAsync<Item>();
        await sqliteAsyncConnection.CreateTableAsync<LogoUrls>();
        await sqliteAsyncConnection.CreateTableAsync<Metro>();
        await sqliteAsyncConnection.CreateTableAsync<MetroStation>();
        await sqliteAsyncConnection.CreateTableAsync<ProfessionalRole>();
        await sqliteAsyncConnection.CreateTableAsync<Salary>();
        await sqliteAsyncConnection.CreateTableAsync<Schedule>();
        await sqliteAsyncConnection.CreateTableAsync<Snippet>();
        await sqliteAsyncConnection.CreateTableAsync<SQLite.DTOs.Type>();

        base.OnStart();
    }
}
