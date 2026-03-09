using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Calligraphy.Presentation.ViewModels;
using Calligraphy.Presentation.Views.Controls;

namespace Calligraphy.Presentation.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        Loaded += SettingsView_Loaded;
    }

    private void SettingsView_Loaded(object sender, RoutedEventArgs e)
    {
        LoadColorButtons();
    }

    private void LoadColorButtons()
    {
        if (DataContext is not SettingsViewModel viewModel) return;

        ColorPanel.Children.Clear();

        foreach (var colorOption in viewModel.AvailableColors)
        {
            var button = new ColorPickerButton
            {
                PencilColor = colorOption.Brush,
                Margin = new Thickness(10),
                ToolTip = colorOption.Name,
                DataContext = colorOption
            };

            button.SetBinding(ColorPickerButton.IsSelectedProperty,
                new Binding(nameof(colorOption.IsSelected))
                {
                    Source = colorOption,
                    Mode = BindingMode.TwoWay
                });

            button.ColorSelected += (sender, args) => viewModel.SelectColor(colorOption);

            ColorPanel.Children.Add(button);
        }
    }
}