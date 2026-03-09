using System.Windows;
using Calligraphy.Application;
using Calligraphy.Presentation.ColorHandling;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views;
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

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
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

        // Register Views
        services.AddTransient<SettingsView>();
        services.AddSingleton<MainWindow>();
        services.AddTransient<TutorialView>();
    }
}