using System.Windows;
using System.Windows.Controls;

namespace Calligraphy.Presentation.Views.Controls;

public partial class GoldStar : UserControl
{
    public GoldStar()
    {
        InitializeComponent();
    }

    public double StarWidth
    {
        get => (double)GetValue(StarWidthProperty);
        set => SetValue(StarWidthProperty, value);
    }

    public static readonly DependencyProperty StarWidthProperty =
        DependencyProperty.Register(nameof(StarWidth), typeof(double), typeof(GoldStar), new PropertyMetadata(40.0));

    public double StarHeight
    {
        get => (double)GetValue(StarHeightProperty);
        set => SetValue(StarHeightProperty, value);
    }

    public static readonly DependencyProperty StarHeightProperty =
        DependencyProperty.Register(nameof(StarHeight), typeof(double), typeof(GoldStar), new PropertyMetadata(40.0));
}