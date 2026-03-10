using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calligraphy.Presentation.ColorHandling;

public class DrawingState : ObservableObject
{
    public Brush PenColor
    {
        get;
        set => SetProperty(ref field, value);
    } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
}
