using System.Windows;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views;

namespace Calligraphy.Presentation;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };
        MainWindow.Show();
        
        base.OnStartup(e);
    }
}