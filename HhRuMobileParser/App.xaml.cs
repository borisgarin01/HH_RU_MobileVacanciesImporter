using Models.Models;
using SQLite;

namespace HhRuMobileParser;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
    protected override async void OnStart()
    {
        base.OnStart();
    }
}
