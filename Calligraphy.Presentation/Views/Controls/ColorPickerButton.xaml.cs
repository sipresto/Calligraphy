using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Calligraphy.Presentation.Views.Controls;

public partial class ColorPickerButton : UserControl
{
    public static readonly DependencyProperty PencilColorProperty =
        DependencyProperty.Register(
            nameof(PencilColor),
            typeof(Brush),
            typeof(ColorPickerButton),
            new PropertyMetadata(Brushes.Black));

    public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.Register(
            nameof(IsSelected),
            typeof(bool),
            typeof(ColorPickerButton),
            new PropertyMetadata(false, OnIsSelectedChanged));

    public static readonly RoutedEvent ColorSelectedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ColorSelected),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ColorPickerButton));

    public ColorPickerButton()
    {
        InitializeComponent();
    }

    public Brush PencilColor
    {
        get => (Brush)GetValue(PencilColorProperty);
        set => SetValue(PencilColorProperty, value);
    }

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public event RoutedEventHandler ColorSelected
    {
        add => AddHandler(ColorSelectedEvent, value);
        remove => RemoveHandler(ColorSelectedEvent, value);
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(ColorSelectedEvent, this));
    }

    private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ColorPickerButton button)
        {
            bool isSelected = (bool)e.NewValue;

            var image = button.ColorButton.Content as Grid;
            if (image?.Children[0] is Image background)
            {
                background.Source = new BitmapImage(
                    new Uri(
                        isSelected
                            ? "/Resources/Assets/Images/Buttons/Pressed/Butto-pressed.png"
                            : "/Resources/Assets/Images/Buttons/Butto.png",
                        UriKind.Relative));
            }
        }
    }
}