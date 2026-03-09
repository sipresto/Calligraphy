using System.Windows.Media;

namespace Calligraphy.Presentation.ColorHandling;

public class ColorOptions
{
    public IReadOnlyList<ColorOption> GetAvailableColors() =>
    [
        new("Black",  new SolidColorBrush(Color.FromRgb(0, 0,  0))),
        new("Red",    new SolidColorBrush(Color.FromRgb(231, 76,  60))),
        new("Blue",   new SolidColorBrush(Color.FromRgb(52,  152, 219))),
        new("Green",  new SolidColorBrush(Color.FromRgb(46,  204, 113))),
        new("Yellow", new SolidColorBrush(Color.FromRgb(241, 196, 15))),
        new("Orange", new SolidColorBrush(Color.FromRgb(230, 126, 34))),
        new("Purple", new SolidColorBrush(Color.FromRgb(155, 89,  182))),
        new("Pink",   new SolidColorBrush(Color.FromRgb(253, 121, 168))),
        new("Teal",   new SolidColorBrush(Color.FromRgb(46,  104, 100))),
        new("Indigo", new SolidColorBrush(Color.FromRgb(52,  12,  219))),
    ];
}