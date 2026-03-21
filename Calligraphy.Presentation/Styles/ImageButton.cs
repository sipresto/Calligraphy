using System.Windows;
using System.Windows.Media;

namespace Calligraphy.Presentation.Styles;

public static class ImageButton
{
    public static readonly DependencyProperty NormalImageProperty =
        DependencyProperty.RegisterAttached(
            "NormalImage",
            typeof(ImageSource),
            typeof(ImageButton),
            new PropertyMetadata(null));

    public static readonly DependencyProperty PressedImageProperty =
        DependencyProperty.RegisterAttached(
            "PressedImage",
            typeof(ImageSource),
            typeof(ImageButton),
            new PropertyMetadata(null));

    public static ImageSource GetNormalImage(DependencyObject obj) => (ImageSource)obj.GetValue(NormalImageProperty);
    public static void SetNormalImage(DependencyObject obj, ImageSource value) => obj.SetValue(NormalImageProperty, value);

    public static ImageSource GetPressedImage(DependencyObject obj) => (ImageSource)obj.GetValue(PressedImageProperty);
    public static void SetPressedImage(DependencyObject obj, ImageSource value) => obj.SetValue(PressedImageProperty, value);
}