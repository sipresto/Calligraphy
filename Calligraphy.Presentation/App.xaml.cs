using System.IO;
using System.Reflection;
using System.Windows;
using Calligraphy.Application;
using Calligraphy.Presentation.ColorHandling;
using Calligraphy.Domain.Configuration;
using Calligraphy.Infrastructure;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation;

public partial class App : System.Windows.Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
        
        InitializeDatabase();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {

        // Register DbContext
        services.AddDbContext<CallyDbContext>(options =>
            options.UseSqlite("Data Source=Cally.db"));
        services.AddScoped<IRepository, Repository>();
        
        // Register Configuration
        var configuration = LoadConfiguration();
        var gameSettings = configuration.GetSection("GameSettings").Get<GameSettings>();
        services.AddSingleton(gameSettings);
        
        services.AddSingleton<DrawingState>();
        services.AddSingleton<ColorOptions>();

        // Register game services
        services.AddTransient<InfinityRaceService>();
        services.AddTransient<TraceGameService>();
        services.AddTransient<ShapeDrawService>();

        // Register ViewModels
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<TutorialViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddTransient<TimedTraceGameViewModel>();
        services.AddTransient<InfinityRaceViewModel>();
        services.AddTransient<ShapeDrawViewModel>();
        services.AddTransient<CategoryViewModel>();
        services.AddTransient<LevelViewModel>();

        // Register Views
        services.AddTransient<SettingsView>();
        services.AddSingleton<MainWindow>();
        services.AddTransient<TutorialView>();
    }

    private IConfiguration LoadConfiguration()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "Calligraphy.Presentation.Resources.appsettings.json";
        
        using var stream = assembly.GetManifestResourceStream(resourceName);
        
        if (stream == null)
        {
            throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");
        }

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        
        return config;
    }

    private void InitializeDatabase()
    {
        using var scope = ServiceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CallyDbContext>();

        context.CreateDatabase(false);
    }
}