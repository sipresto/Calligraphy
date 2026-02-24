using System.Windows;
using System.Windows.Controls;

namespace Calligraphy.Presentation.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Button clicked!");
    }
}