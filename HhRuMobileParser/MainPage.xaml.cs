using HhRuMobileParser.ViewModels;

namespace HhRuMobileParser;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageModel();
    }
}
