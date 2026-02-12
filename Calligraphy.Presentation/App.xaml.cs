using System.Windows;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Calligraphy.Presentation;


public partial class App : Application
{
	
	private readonly ServiceProvider _serviceProvider;
	public App()
	{
		IServiceCollection services = new ServiceCollection();
		services.AddSingleton<MainWindow>(provider => new MainWindow
		{
			DataContext = provider.GetRequiredService<MainViewModel>()
		});
		
		services.AddSingleton<MainViewModel>();
		services.AddSingleton<HomeViewModel>();
		services.AddSingleton<InfinityRaceViewModel>();

		_serviceProvider = services.BuildServiceProvider();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
		mainWindow.Show();
		base.OnStartup(e);
	}
	
}