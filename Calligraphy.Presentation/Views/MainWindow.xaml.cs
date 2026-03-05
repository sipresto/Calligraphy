using System.Windows;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}