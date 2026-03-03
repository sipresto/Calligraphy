using System.Windows;
using System.Windows.Controls;

namespace Calligraphy.Presentation.Views.Controls;

public partial class MascotFeedbackControl : UserControl
{
    public MascotFeedbackControl()
    {
        InitializeComponent();
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
            new PropertyMetadata(false));

    public bool IsMascotVisible
    {
        get => (bool)GetValue(IsMascotVisibleProperty);
        set => SetValue(IsMascotVisibleProperty, value);
    }

    public void ShowFeedback(int stars, string feedbackMessage = null)
    {
        string message = feedbackMessage ?? stars switch
        {
            3 => "Geweldig! Je hebt het heel goed gedaan",
            2 => "Goed gedaan! Het was al bijna perfect",
            1 => "Niet slecht! Probeer het nog eens en kijk of je meer punten kunt halen",
            0 => "Blijf oefenen! Je kunt het beter doen als je het nog eens probeert",
            _ => ""
        };

        MascotMessage = message;
        IsMascotVisible = true;
    }
    
    public void Hide()
    {
        IsMascotVisible = false;
    }
}