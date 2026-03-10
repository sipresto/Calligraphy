using System.Collections.ObjectModel;
using System.Windows.Media;
using Calligraphy.Presentation.ColorHandling;
using CommunityToolkit.Mvvm.Input;

namespace Calligraphy.Presentation.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;
    private readonly DrawingState _drawingState;
    private ColorOption _selectedColor;

    public SettingsViewModel(MainViewModel mainViewModel, DrawingState drawingState, ColorOptions colorOptions)
    {
        _mainViewModel = mainViewModel;
        _drawingState = drawingState;

        foreach (var color in colorOptions.GetAvailableColors())
            AvailableColors.Add(color);

        var currentColor = AvailableColors.FirstOrDefault(c =>
                               c.Brush is SolidColorBrush b1 &&
                               _drawingState.PenColor is SolidColorBrush b2 &&
                               b1.Color == b2.Color)
                           ?? AvailableColors[0];

        SelectColor(currentColor);
    }

    public ObservableCollection<ColorOption> AvailableColors { get; } = new();

    public ColorOption SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (_selectedColor == value) return;
            _selectedColor = value;
            OnPropertyChanged();
        }
    }

    public void SelectColor(ColorOption colorOption)
    {
        SelectedColor = colorOption;
        _drawingState.PenColor = colorOption.Brush;

        foreach (var color in AvailableColors)
            color.IsSelected = color == colorOption;
    }

    [RelayCommand]
    private void Close() => _mainViewModel.NavigateToHome();
}