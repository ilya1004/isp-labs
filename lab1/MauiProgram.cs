using lab1.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

namespace lab1;

public static class MauiProgram
{

    public const string DATABASE_NAME = "friends.db";
    public static IServiceCollection services = new ServiceCollection();
    public static IDbService? database = new SQLiteService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
    
    public static MauiApp CreateMauiApp()
    {
        services.AddTransient<IDbService, SQLiteService>();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<IDbService, SQLiteService> ();

        var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5091"
            : "https://localhost:7091";

        builder.Services.AddHttpClient<IRateService,RateService>(opt => opt.BaseAddress = new Uri(baseAddress));
        
        //builder.Services.AddSingleton<IRateService, RateService>();
        builder.Services.AddSingleton<CurrencyConverter>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
