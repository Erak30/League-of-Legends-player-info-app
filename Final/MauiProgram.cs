using Microsoft.Extensions.Logging;

namespace Final
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Spiegel_TT_Bold.ttf", "SpiegelTTBold");
                    fonts.AddFont("Spiegel_TT_Italic.ttf", "SpiegelTTItalic");
                    fonts.AddFont("Spiegel_TT_Regular.ttf", "SpiegelTTRegular");
                    fonts.AddFont("Spiegel_TT_Semibold.ttf", "SpiegelTTSemibold");
                    fonts.AddFont("Spiegel_TT_Semibold_Italic.ttf", "SpiegelTTSemiboldItalic");
                    fonts.AddFont("BeaufortforLOL-Medium.ttf", "BeaufortforLOLMedium");
                    fonts.AddFont("BeaufortforLOL-Bold.ttf", "BeaufortforLOLBold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
