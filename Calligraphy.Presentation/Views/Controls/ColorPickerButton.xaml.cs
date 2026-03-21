using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Calligraphy.Presentation.Views.Controls;

public partial class ColorPickerButton : UserControl
{
    public static readonly DependencyProperty PencilColorProperty =
        DependencyProperty.Register(nameof(PencilColor), typeof(Brush), typeof(ColorPickerButton),
            new PropertyMetadata(Brushes.Black));

    public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(ColorPickerButton),
            new PropertyMetadata(false));

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ColorPickerButton),
            new PropertyMetadata(null));

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ColorPickerButton),
            new PropertyMetadata(null));

    public ColorPickerButton() => InitializeComponent();

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

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        if (Command?.CanExecute(CommandParameter) == true)
            Command.Execute(CommandParameter);
    }
}