using System.Windows.Media;
using Calligraphy.Presentation.ViewModels;

namespace Calligraphy.Presentation.ColorHandling;

public class ColorOption : ViewModelBase
{
    private bool _isSelected;

    public ColorOption(string name, Brush brush)
    {
        Name = name;
        Brush = brush;
    }

    public string Name { get; }
    public Brush Brush { get; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected == value) return;
            _isSelected = value;
            OnPropertyChanged();
        }
    }
}