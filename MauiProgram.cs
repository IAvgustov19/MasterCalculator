using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Calculator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //Подлючение шрифтов, настройка и инициализация небходимых данных платформы
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Montserrat-Medium.ttf", "medium");
                    fonts.AddFont("Montserrat-Regular.ttf", "regular");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "semiBold");
                    fonts.AddFont("Montserrat-Bold.ttf", "bold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}