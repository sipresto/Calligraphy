using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
                ToolTip = colorOption.Name
            };

            button.ColorSelected += (s, e) =>
            {
                viewModel.SelectedColor = colorOption;
                UpdateSelection(button);
            };

            ColorPanel.Children.Add(button);
        }
    }

    private void UpdateSelection(ColorPickerButton selectedButton)
    {
        foreach (var child in ColorPanel.Children)
        {
            if (child is ColorPickerButton button)
            {
                button.IsSelected = (button == selectedButton);
            }
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SettingsViewModel viewModel)
        {
            viewModel.CloseCommand?.Execute(null);
        }
    }

    private void Overlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is SettingsViewModel viewModel)
        {
            viewModel.CloseCommand?.Execute(null);
        }
    }

    private void Popup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
    }
}
