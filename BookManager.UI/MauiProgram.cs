using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using BookManager.App;
using BookManager.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using BookManager.Persistence.Data;

namespace BookManager.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "BookManager.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream!);

        var connectionString = builder.Configuration.GetConnectionString("SqliteConnections");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";

        connectionString = string.Format(connectionString!, dataDirectory);

        var options = new DbContextOptionsBuilder<BookManagerDbContext>()
            .UseSqlite(connectionString)
            .Options;

        builder.Services.AddApplication()
                        .AddPersistence(options)
                        .AddPages()
                        .AddViewModels();

        DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();        


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
