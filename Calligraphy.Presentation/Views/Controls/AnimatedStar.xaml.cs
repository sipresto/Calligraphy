using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace Calligraphy.Presentation.Views.Controls;

public partial class AnimatedStar : UserControl
{
    private static readonly SoundPlayer Player = new(
        System.Windows.Application.GetResourceStream(
            new Uri("pack://application:,,,/Resources/Assets/Sounds/star.wav"))!.Stream);

    public static readonly DependencyProperty IsFilledProperty =
        DependencyProperty.Register(
            nameof(IsFilled),
            typeof(bool),
            typeof(AnimatedStar),
            new PropertyMetadata(false, OnIsFilledChanged));

    public static readonly DependencyProperty PlaySoundProperty =
        DependencyProperty.Register(
            nameof(PlaySound),
            typeof(bool),
            typeof(AnimatedStar),
            new PropertyMetadata(true));

    public AnimatedStar()
    {
        InitializeComponent();
    }

    public bool IsFilled
    {
        get => (bool)GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }

    public bool PlaySound
    {
        get => (bool)GetValue(PlaySoundProperty);
        set => SetValue(PlaySoundProperty, value);
    }

    private static void OnIsFilledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is AnimatedStar star && (bool)e.NewValue && star.PlaySound)
            Player.Play();
    }
}