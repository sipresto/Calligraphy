using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    private ColorOption _selectedColor;

    public SettingsViewModel()
    {
        InitializeColors();
        CloseCommand = new RelayCommand(ExecuteClose);
        
        // Set default color (e.g., black)
        SelectedColor = AvailableColors[0];
    }

    public ObservableCollection<ColorOption> AvailableColors { get; } = new();

    public ColorOption SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (_selectedColor != value)
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand CloseCommand { get; set; }

    private void InitializeColors()
    {
        // Add child-friendly colors
        AvailableColors.Add(new ColorOption("Black", new SolidColorBrush(Colors.Black)));
        AvailableColors.Add(new ColorOption("Red", new SolidColorBrush(Color.FromRgb(231, 76, 60))));
        AvailableColors.Add(new ColorOption("Blue", new SolidColorBrush(Color.FromRgb(52, 152, 219))));
        AvailableColors.Add(new ColorOption("Green", new SolidColorBrush(Color.FromRgb(46, 204, 113))));
        AvailableColors.Add(new ColorOption("Yellow", new SolidColorBrush(Color.FromRgb(241, 196, 15))));
        AvailableColors.Add(new ColorOption("Orange", new SolidColorBrush(Color.FromRgb(230, 126, 34))));
        AvailableColors.Add(new ColorOption("Purple", new SolidColorBrush(Color.FromRgb(155, 89, 182))));
        AvailableColors.Add(new ColorOption("Pink", new SolidColorBrush(Color.FromRgb(253, 121, 168))));
        AvailableColors.Add(new ColorOption("Pink", new SolidColorBrush(Color.FromRgb(46, 104, 100))));
        AvailableColors.Add(new ColorOption("Pink", new SolidColorBrush(Color.FromRgb(52, 12, 219))));
    }

    private void ExecuteClose()
    {
        // Close the settings popup
        // This will be handled by the HomeViewModel
    }
}

public class ColorOption
{
    public ColorOption(string name, Brush brush)
    {
        Name = name;
        Brush = brush;
    }

    public string Name { get; }
    public Brush Brush { get; }
}