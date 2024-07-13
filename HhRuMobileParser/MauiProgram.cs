using HhRuMobileParser.SQLite;
using Microsoft.Extensions.Logging;
using Models.Http;

namespace HhRuMobileParser
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<VacanciesRequesterAndExtractorFromHttpResponse>();
            builder.Services.AddSingleton<VacanciesToSQLiteImporter>();
            builder.Services.AddSingleton<MainPage>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
