using System.Windows;
using Calligraphy.Application;
using Calligraphy.Domain;
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
        services.AddTransient<InfinityRaceService>();
        services.AddTransient<GameService>();

        services.AddSingleton<MainViewModel>();
        services.AddTransient<TraceGameViewModel>();
        services.AddTransient<InfinityRaceViewModel>();

        services.AddSingleton<MainWindow>();
    }
}