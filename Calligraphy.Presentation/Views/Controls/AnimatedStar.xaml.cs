using System.Windows;
using System.Windows.Controls;

namespace Calligraphy.Presentation.Views.Controls;

public partial class AnimatedStar : UserControl
{
    public static readonly DependencyProperty IsFilledProperty =
        DependencyProperty.Register(
            nameof(IsFilled),
            typeof(bool),
            typeof(AnimatedStar),
            new PropertyMetadata(false));

    public AnimatedStar()
    {
        InitializeComponent();
    }

    public bool IsFilled
    {
        get => (bool)GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }
}