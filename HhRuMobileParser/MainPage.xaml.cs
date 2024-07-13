using HhRuMobileParser.SQLite;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;
using Models.Http;
using Models.Models;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System.Web;

namespace HhRuMobileParser;

public partial class MainPage : ContentPage
{
    public MainPageModel MainPageModel { get; set; }
    public MainPage(VacanciesRequesterAndExtractorFromHttpResponse vacanciesRequesterAndExtractorFromHttpResponse, VacanciesToSQLiteImporter vacanciesToSQLiteImporter)
    {
        InitializeComponent();

        MainPageModel = new MainPageModel(vacanciesRequesterAndExtractorFromHttpResponse);
        BindingContext = MainPageModel;
    }

}