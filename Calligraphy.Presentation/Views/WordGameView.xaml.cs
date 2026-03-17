using System.Windows;
using System.Windows.Controls;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.Views;

public partial class WordGameView : UserControl
{
    public WordGameView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    
    private WordGameViewModel ViewModel => DataContext as WordGameViewModel;

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null)
            return;

        ResultPopup.DataContext = DataContext;
    }
}