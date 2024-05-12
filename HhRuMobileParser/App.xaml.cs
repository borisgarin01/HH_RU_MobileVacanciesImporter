using HhRuMobileParser.Models;
using HhRuMobileParser.Models.DTOs;
using SQLite;

namespace HhRuMobileParser
{
    public partial class App : Application
    {
        SQLiteAsyncConnection sqliteAsyncConnection = new SQLiteAsyncConnection(DatabasePathHolder.DatabasePath);

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override async void OnStart()
        {
            base.OnStart();
            await sqliteAsyncConnection.CreateTableAsync<Vacancy>();
        }
    }
}
