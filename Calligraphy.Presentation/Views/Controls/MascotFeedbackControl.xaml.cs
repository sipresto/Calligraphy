using System.Windows;
using System.Windows.Controls;
using Calligraphy.Domain;

namespace Calligraphy.Presentation.Views.Controls;

public partial class MascotFeedbackControl : UserControl
{
    public MascotFeedbackControl()
    {
        InitializeComponent();
        Visibility = Visibility.Collapsed;
    }

    public static readonly DependencyProperty MascotMessageProperty =
        DependencyProperty.Register(nameof(MascotMessage), typeof(string), typeof(MascotFeedbackControl),
            new PropertyMetadata(string.Empty));

    public string MascotMessage
    {
        get => (string)GetValue(MascotMessageProperty);
        set => SetValue(MascotMessageProperty, value);
    }

    public static readonly DependencyProperty IsMascotVisibleProperty =
        DependencyProperty.Register(nameof(IsMascotVisible), typeof(bool), typeof(MascotFeedbackControl),
            new PropertyMetadata(false, OnIsMascotVisibleChanged));

    public bool IsMascotVisible
    {
        get => (bool)GetValue(IsMascotVisibleProperty);
        set => SetValue(IsMascotVisibleProperty, value);
    }

    private static void OnIsMascotVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MascotFeedbackControl control)
        {
            control.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public void ShowFeedback(int stars, string feedbackMessage = null)
    {
        string message;

        if (feedbackMessage == null)
        {
            message = stars switch
            {
                3 => "Geweldig! Je het heel goed gedaan",
                2 => "Goed gedaan! Het was al bijna perfect",
                1 => "Niet slecht! Probeer het nog eens en kijk of je meer punten kunt halen",
                0 => "Blijf oefenen! Je kunt het beter doen als je het nog eens probeert",
                _ => ""
            };
        }
        else
        {
            message = feedbackMessage;
        }

        MascotMessage = message;
        IsMascotVisible = true;
    }
    
    public void Hide()
    {
        IsMascotVisible = false;
    }
}